using LibreLegends.Api.Services;
using LibreLegends.Infrastructure.Domain;
using LibreLegends.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibreLegends.Api.Endpoints;

public static class CardsEndpoint
{
    public static IEndpointRouteBuilder MapCardsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/cards", async ([FromServices] ICardRepository cardRepository) =>
            {
                var cards = await cardRepository.GetCards();
                return Results.Ok(cards);
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Gets all cards";
                return operation;
            });

        app.MapGet("/cards/{id:guid}", async ([FromServices] ICardRepository cardRepository, Guid id) =>
            {
                var card = await cardRepository.GetCardById(id);
                return card is not null ? Results.Ok(card) : Results.NotFound();
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Gets a card by ID";
                return operation;
            });

        app.MapGet("/cards/type/{cardType}", async ([FromServices] ICardRepository cardRepository, CardType cardType) =>
            {
                var cards = await cardRepository.GetCardsByType(cardType);
                return Results.Ok(cards);
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Gets cards by type";
                return operation;
            });

        app.MapGet("/cards/creatures", async (
            [FromServices] ICardRepository cardRepository) =>
        {
            var cards = await cardRepository.GetCardsByType(CardType.Creature);

            return Results.Ok(cards);
        });

        app.MapPost("/cards/creatures", async (
                [FromServices] ICardRepository cardRepository,
                [FromServices] ICardValidationService validationService,
                [FromBody] Creature creature) =>
            {
                var (isValid, errorMessage) = validationService.ValidateCard(creature);
                if (!isValid)
                {
                    return Results.BadRequest(new { Error = errorMessage });
                }

                var id = await cardRepository.CreateCard(creature);
                return Results.Created($"/cards/{id}", creature);
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Creates a new creature card";
                return operation;
            });

        app.MapGet("/cards/spells", async (
            [FromServices] ICardRepository cardRepository) =>
        {
            var cards = await cardRepository.GetCardsByType(CardType.Spell);

            return Results.Ok(cards);
        });

        app.MapPost("/cards/spells", async (
                [FromServices] ICardRepository cardRepository,
                [FromServices] ICardValidationService validationService,
                [FromBody] Spell spell) =>
            {
                var (isValid, errorMessage) = validationService.ValidateCard(spell);
                if (!isValid)
                {
                    return Results.BadRequest(new { Error = errorMessage });
                }

                var id = await cardRepository.CreateCard(spell);
                return Results.Created($"/cards/{id}", spell);
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Creates a new spell card";
                return operation;
            });

        app.MapPut("/cards/creatures/{id:guid}", async (
                [FromServices] ICardRepository cardRepository,
                [FromServices] ICardValidationService validationService,
                Guid id,
                [FromBody] Creature creature) =>
            {
                if (id != creature.Id)
                {
                    return Results.BadRequest(new { Error = "ID mismatch between URL and body" });
                }

                var existingCard = await cardRepository.GetCardById(id);
                if (existingCard is null)
                {
                    return Results.NotFound();
                }

                if (existingCard is not Creature)
                {
                    return Results.BadRequest(new { Error = "Cannot update non-creature card as a creature" });
                }

                var (isValid, errorMessage) = validationService.ValidateCard(creature);
                if (!isValid)
                {
                    return Results.BadRequest(new { Error = errorMessage });
                }

                var success = await cardRepository.UpdateCard(creature);
                return success ? Results.NoContent() : Results.NotFound();
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Updates a creature card";
                return operation;
            });

        app.MapPut("/cards/spells/{id:guid}", async (
                [FromServices] ICardRepository cardRepository,
                [FromServices] ICardValidationService validationService,
                Guid id,
                [FromBody] Spell spell) =>
            {
                if (id != spell.Id)
                {
                    return Results.BadRequest(new { Error = "ID mismatch between URL and body" });
                }

                var existingCard = await cardRepository.GetCardById(id);
                if (existingCard is null)
                {
                    return Results.NotFound();
                }

                if (existingCard is not Spell)
                {
                    return Results.BadRequest(new { Error = "Cannot update non-spell card as a spell" });
                }

                var (isValid, errorMessage) = validationService.ValidateCard(spell);
                if (!isValid)
                {
                    return Results.BadRequest(new { Error = errorMessage });
                }

                var success = await cardRepository.UpdateCard(spell);
                return success ? Results.NoContent() : Results.NotFound();
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Updates a spell card";
                return operation;
            });

        app.MapDelete("/cards/{id:guid}", async ([FromServices] ICardRepository cardRepository, Guid id) =>
            {
                var success = await cardRepository.DeleteCard(id);
                return success ? Results.NoContent() : Results.NotFound();
            })
            .WithOpenApi(operation =>
            {
                operation.Summary = "Deletes a card";
                return operation;
            });

        app.MapDelete("/cards", async ([FromServices] ICardRepository cardRepository) =>
            {
                await cardRepository.Delete();

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