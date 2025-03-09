using LibreLegends.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibreLegends.Infrastructure.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddLibreLegendsInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDataSource("libreLegendsDb");
        builder.Services.AddScoped<ICardRepository, CardRepository>();

        return builder;
    }
}