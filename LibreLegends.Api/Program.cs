using LibreLegends.Api.Endpoints;
using LibreLegends.CardManagement.DependencyInjection;
using LibreLegends.Infrastructure.DependencyInjection;
using LibreLegends.MatchMaking.DependencyInjection;
using LibreLegends.ServiceDefaults;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors();
    builder.Services.AddOpenApi();
    builder.AddServiceDefaults();

    builder.AddInfrastructure();
    builder.AddCardManagement();
    builder.AddMatchMaking();

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
    app.MapMatchesEndpoint();

    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}