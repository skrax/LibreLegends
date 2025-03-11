using LibreLegends.Api.Endpoints;
using LibreLegends.CardManagement.Application.DependencyInjection;
using LibreLegends.Infrastructure.DependencyInjection;
using LibreLegends.ServiceDefaults;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors();
    builder.Services.AddOpenApi();
    builder.AddServiceDefaults();

    builder.AddInfrastructureNpgsql();
    builder.AddCardManagement();

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