using LibreLegends.Api.Endpoints;
using LibreLegends.Api.Services;
using LibreLegends.Infrastructure.DependencyInjection;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors();
    builder.Services.AddOpenApi();
    builder.AddServiceDefaults();
    builder.AddLibreLegendsInfrastructure();

    builder.Services.AddScoped<ICardValidationService, CardValidationService>();

    var app = builder.Build();

    app.UseCors(x =>
    {
        if (app.Environment.IsDevelopment())
        {
            x.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    });

    app.MapOpenApi();
    app.UseHttpsRedirection();

    app.MapCardsEndpoint();

    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}