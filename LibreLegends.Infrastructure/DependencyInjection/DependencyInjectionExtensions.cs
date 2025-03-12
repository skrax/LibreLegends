using Dapper;
using LibreLegends.Domain.Models;
using LibreLegends.Domain.Models.Cards;
using LibreLegends.Infrastructure.SqlTypeHandler;
using LibreLegends.Infrastructure.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibreLegends.Infrastructure.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddInfrastructureNpgsql(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDataSource("libreLegendsDb");

        builder.Services
            .AddScoped<ICreatureStore, NpgsqlCreatureStore>()
            .AddScoped<ISpellStore, NpgsqlSpellStore>()
            .AddScoped<ICardStore, NpgsqlCardStore>();

        SqlMapper.AddTypeHandler(new JsonBTypeHandler<CardBehavior>());

        return builder;
    }
}