using Dapper;
using LibreLegends.Domain.Models.Cards;
using LibreLegends.Infrastructure.SqlTypeHandler;
using LibreLegends.Infrastructure.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibreLegends.Infrastructure.DependencyInjection;

public static class DependencyInjectionExtensions
{
    internal static IHostApplicationBuilder AddDatabase(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDataSource("Database");

        return builder;
    }

    internal static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<ICreatureStore, NpgsqlCreatureStore>()
            .AddScoped<ISpellStore, NpgsqlSpellStore>()
            .AddScoped<ICardStore, NpgsqlCardStore>();

        return builder;
    }

    internal static IHostApplicationBuilder AddSqlMapperTypeHandlers(this IHostApplicationBuilder builder)
    {
        SqlMapper.AddTypeHandler(new JsonBTypeHandler<CardBehavior>());

        return builder;
    }

    public static IHostApplicationBuilder AddInfrastructureNpgsql(this IHostApplicationBuilder builder)
    {
        return builder
            .AddDatabase()
            .AddServices()
            .AddSqlMapperTypeHandlers();
    }
}