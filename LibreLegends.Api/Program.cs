using LibreLegends.Api.Services;
using LibreLegends.Infrastructure.DependencyInjection;
using LibreLegends.Infrastructure.Domain;
using LibreLegends.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors();
    builder.AddServiceDefaults();
    builder.AddLibreLegendsInfrastructure();
    builder.Services.AddOpenApi();

    builder.Services.AddScoped<ICardValidationService, CardValidationService>();

    var app = builder.Build();

    app.UseCors(x => { x.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod(); });

    app.MapOpenApi();
    app.UseHttpsRedirection();

    // Get all cards
    app.MapGet("/cards", async ([FromServices] ICardRepository cardRepository) =>
        {
            var cards = await cardRepository.GetCards();
            return Results.Ok(cards);
        })
        .WithOpenApi(operation => { operation.Summary = "Gets all cards"; return operation; });

    // Get card by ID
    app.MapGet("/cards/{id}", async ([FromServices] ICardRepository cardRepository, Guid id) =>
        {
            var card = await cardRepository.GetCardById(id);
            return card is not null ? Results.Ok(card) : Results.NotFound();
        })
        .WithOpenApi(operation => { operation.Summary = "Gets a card by ID"; return operation; });

    // Get cards by type
    app.MapGet("/cards/type/{cardTypeId}", async ([FromServices] ICardRepository cardRepository, int cardTypeId) =>
        {
            var cards = await cardRepository.GetCardsByType(cardTypeId);
            return Results.Ok(cards);
        })
        .WithOpenApi(operation => { operation.Summary = "Gets cards by type"; return operation; });

    // Create creature card
    app.MapPost("/cards/creature", async (
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
        .WithOpenApi(operation => { operation.Summary = "Creates a new creature card"; return operation; });

    // Create spell card
    app.MapPost("/cards/spell", async (
        [FromServices] ICardRepository cardRepository,
        [FromServices] ICardValidationService validationService,
        [FromBody] Spell spell) =>
        {
            // Ensure we have a valid GUID
            if (spell.Id == Guid.Empty)
            {
                spell.Id = Guid.NewGuid();
            }

            var (isValid, errorMessage) = validationService.ValidateCard(spell);
            if (!isValid)
            {
                return Results.BadRequest(new { Error = errorMessage });
            }

            var id = await cardRepository.CreateCard(spell);
            return Results.Created($"/cards/{id}", spell);
        })
        .WithOpenApi(operation => { operation.Summary = "Creates a new spell card"; return operation; });

    // Update creature card
    app.MapPut("/cards/creature/{id}", async (
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
        .WithOpenApi(operation => { operation.Summary = "Updates a creature card"; return operation; });

    // Update spell card
    app.MapPut("/cards/spell/{id}", async (
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
        .WithOpenApi(operation => { operation.Summary = "Updates a spell card"; return operation; });

    // Delete card
    app.MapDelete("/cards/{id}", async ([FromServices] ICardRepository cardRepository, Guid id) =>
        {
            var success = await cardRepository.DeleteCard(id);
            return success ? Results.NoContent() : Results.NotFound();
        })
        .WithOpenApi(operation => { operation.Summary = "Deletes a card"; return operation; });
    
    
    // Delete all cards
    app.MapDelete("/cards", async ([FromServices] ICardRepository cardRepository) =>
        {
            await cardRepository.Delete();
            
            return Results.NoContent();
        })
        .WithOpenApi(operation => { operation.Summary = "Deletes all cards"; return operation; });

    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
