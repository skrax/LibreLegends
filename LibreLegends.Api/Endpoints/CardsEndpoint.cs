using LibreLegends.Api.Mapper;
using LibreLegends.Api.Mapper.CardManagement;
using LibreLegends.Api.Models.Request;
using LibreLegends.Api.Models.Request.CardManagement;
using LibreLegends.CardManagement.Services;
using LibreLegends.Domain.Models;
using LibreLegends.Domain.Models.Cards;
using Microsoft.AspNetCore.Mvc;

namespace LibreLegends.Api.Endpoints;

public static class CardsEndpoint
{
    public static IEndpointRouteBuilder MapCardsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/cards", async ([FromServices] ICardManagementService cardManagementService) =>
            {
                var cards = await cardManagementService.GetCardsAsync();

                var response = cards.Select(x => x.AsCardTo());

                return Results.Ok(response);
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Gets all cards";
                return operation;
            });

        app.MapGet("/cards/{id:guid}", async ([FromServices] ICardManagementService cardManagementService, Guid id) =>
            {
                var card = await cardManagementService.GetCardByIdAsync(id);

                var response = card?.AsCardTo();

                return response is not null ? Results.Ok(response) : Results.NotFound();
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Gets a card by ID";
                return operation;
            });

        app.MapGet("/cards/type/{cardType}",
                async ([FromServices] ICardManagementService cardManagementService, CardType cardType) =>
                {
                    var cards = await cardManagementService.GetCardsByTypeAsync(cardType);

                    var response = cards.Select(x => x.AsCardTo());

                    return Results.Ok(response);
                })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Gets cards by type";
                return operation;
            });

        app.MapGet("/cards/creatures", async (
            [FromServices] ICardManagementService cardManagementService) =>
        {
            var cards = await cardManagementService.GetCardsByTypeAsync(CardType.Creature);

            var response = cards.Select(x => x.AsCardTo());

            return Results.Ok(response);
        });

        app.MapPost("/cards/creatures", async (
                [FromServices] ICardManagementService cardManagementService,
                [FromBody] CreateOrUpdateCreatureDto request) =>
            {
                var creature = await cardManagementService.CreateCreatureAsync(request.AsCreateCreatureRequest());

                var response = creature.AsCreatureDto();

                return Results.Created($"/cards/{response.Id}", response);
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Creates a new creature card";
                return operation;
            });

        app.MapGet("/cards/spells", async (
            [FromServices] ICardManagementService cardManagementService) =>
        {
            var cards = await cardManagementService.GetCardsByTypeAsync(CardType.Spell);

            var response = cards.Select(x => x.AsCardTo());

            return Results.Ok(response);
        });

        app.MapPost("/cards/spells", async (
                [FromServices] ICardManagementService cardManagementService,
                [FromBody] CreateOrUpdateSpellDto request) =>
            {
                var spell = await cardManagementService.CreateSpellAsync(request.AsCreateSpellRequest());

                var response = spell.AsSpellDto();

                return Results.Created($"/cards/{response.Id}", response);
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Creates a new spell card";
                return operation;
            });

        app.MapPut("/cards/creatures/{id:guid}", async (
                [FromServices] ICardManagementService cardManagementService,
                Guid id,
                [FromBody] CreateOrUpdateCreatureDto request) =>
            {
                var creature = await cardManagementService.UpdateCreatureAsync(request.AsUpdateCreatureRequest(id));

                var response = creature?.AsCreatureDto();

                return response is not null
                    ? Results.NoContent()
                    : Results.NotFound();
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Updates a creature card";
                return operation;
            });

        app.MapPut("/cards/spells/{id:guid}", async (
                [FromServices] ICardManagementService cardManagementService,
                Guid id,
                [FromBody] CreateOrUpdateSpellDto request) =>
            {
                var spell = await cardManagementService.UpdateSpellAsync(request.AsUpdateSpellRequest(id));

                var response = spell?.AsSpellDto();

                return response is not null
                    ? Results.NoContent()
                    : Results.NotFound();
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Updates a spell card";
                return operation;
            });

        app.MapDelete("/cards/{id:guid}",
                async ([FromServices] ICardManagementService cardManagementService, Guid id) =>
                {
                    await cardManagementService.DeleteByIdAsync(id);

                    return Results.NoContent();
                })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Deletes a card";
                return operation;
            });

        app.MapDelete("/cards", async ([FromServices] ICardManagementService cardManagementService) =>
            {
                await cardManagementService.DeleteAllCardsAsync();

                return Results.NoContent();
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Deletes all cards";
                return operation;
            });

        return app;
    }
}