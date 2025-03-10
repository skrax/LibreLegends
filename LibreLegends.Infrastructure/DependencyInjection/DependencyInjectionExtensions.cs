using Dapper;
using LibreLegends.Infrastructure.Domain;
using LibreLegends.Infrastructure.Repositories;
using LibreLegends.Infrastructure.SqlTypeHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibreLegends.Infrastructure.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddLibreLegendsInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDataSource("libreLegendsDb");

        builder.Services.AddScoped<ICardRepository, CardRepository>();

        SqlMapper.AddTypeHandler(new JsonBTypeHandler<CreatureAbilities>());
        SqlMapper.AddTypeHandler(new JsonBTypeHandler<SpellAbilities>());

        return builder;
    }
}