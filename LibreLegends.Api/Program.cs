using LibreLegends.Infrastructure.DependencyInjection;
using LibreLegends.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors();
    builder.AddServiceDefaults();
    builder.AddLibreLegendsInfrastructure();
    builder.Services.AddOpenApi();

    var app = builder.Build();

    app.UseCors(x => { x.SetIsOriginAllowed(origin => origin is "localhost"); });

    app.MapOpenApi();
    app.UseHttpsRedirection();

    app.MapGet("/cards", async ([FromServices] ICardRepository cardRepository) =>
        {
            var cards = await cardRepository.GetCards();

            return Results.Ok(cards);
        })
        .WithOpenApi();

    app.Run();
}
catch(Exception e)
{
    Console.WriteLine(e);
    throw;
}