using LibreLegends.Api.Mapper.MatchMaking;
using LibreLegends.Api.Models.Request.MatchMaking;
using LibreLegends.MatchMaking.Exceptions;
using LibreLegends.MatchMaking.Models.Request;
using LibreLegends.MatchMaking.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibreLegends.Api.Endpoints;

public static class MatchesEndpoint
{
    public static IEndpointRouteBuilder MapMatchesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/matches", async ([FromServices] IMatchMakingService matchMakingService) =>
            {
                var matches = await matchMakingService.GetMatchesAsync();

                var response = matches.Select(x => x.AsMatchDto());

                return Results.Ok(response);
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Gets all matches";
                return operation;
            });

        app.MapGet("/matches/{id:guid}", async ([FromServices] IMatchMakingService matchMakingService, Guid id) =>
            {
                var match = await matchMakingService.GetMatchByIdAsync(id);

                if (match is null)
                {
                    return Results.NotFound();
                }

                var response = match.AsMatchDto();

                return Results.Ok(response);
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Gets a match by ID";
                return operation;
            });

        app.MapPost("/matches", async ([FromServices] IMatchMakingService matchMakingService,
                [FromBody] CreateMatchDto request,
                HttpContext httpContext) =>
            {
                var match = await matchMakingService.CreateAsync(new CreateMatchRequest
                {
                    Name = request.Name,
                    PlayerName = request.PlayerName
                });

                var response = match.AsMatchDto();

                httpContext.Response.Headers["LibreLegends-PlayerToken"] = match.PlayerToken.ToString();

                return Results.Ok(response);
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Creates a new match";
                return operation;
            });

        app.MapPost("/matches/{id:guid}/join", async ([FromServices] IMatchMakingService matchMakingService,
            Guid id,
            [FromBody] JoinMatchDto request,
            HttpContext httpContext) =>
        {
            try
            {
                var match = await matchMakingService.JoinMatchAsync(new JoinMatchRequest
                {
                    MatchId = id,
                    PlayerName = request.PlayerName
                });

                httpContext.Response.Headers["LibreLegends-PlayerToken"] = match.PlayerToken.ToString();

                return Results.Ok();
            }
            catch (MatchNotFoundException)
            {
                return Results.NotFound();
            }
        }).WithOpenApi(operation =>
        {
            operation.Summary = "Join an existing match";
            return operation;
        });

        app.MapPost("/matches/{id:guid}/leave", async ([FromServices] IMatchMakingService matchMakingService,
            Guid id,
            [FromHeader(Name = "LibreLegends-PlayerToken")]
            Guid playerToken
        ) =>
        {
            try
            {
                await matchMakingService.LeaveMatchAsync(new LeaveMatchRequest
                {
                    MatchId = id,
                    PlayerToken = playerToken
                });

                return Results.Ok();
            }
            catch (MatchNotFoundException)
            {
                return Results.NotFound();
            }
        }).WithOpenApi(operation =>
        {
            operation.Summary = "Leave a match";
            return operation;
        });

        return app;
    }
}