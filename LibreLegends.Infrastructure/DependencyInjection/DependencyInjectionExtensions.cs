using Dapper;
using LibreLegends.Domain.Models.Cards;
using LibreLegends.Infrastructure.SqlTypeHandler;
using LibreLegends.Infrastructure.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibreLegends.Infrastructure.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddInfrastructureDatabaseNpgsql(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDataSource("Database");

        return builder;
    }

    public static IHostApplicationBuilder AddInfrastructureServicesNpgsql(this IHostApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<ICreatureStore, NpgsqlCreatureStore>()
            .AddScoped<ISpellStore, NpgsqlSpellStore>()
            .AddScoped<ICardStore, NpgsqlCardStore>();

        return builder;
    }

    public static IHostApplicationBuilder AddInfrastructureDapperSqlMapperTypeHandlersNpgsql(this IHostApplicationBuilder builder)
    {
        SqlMapper.AddTypeHandler(new JsonBTypeHandler<CardBehavior>());

        return builder;
    }

    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMatchStore, InMemoryMatchStore>();
        
        return builder
            .AddInfrastructureDatabaseNpgsql()
            .AddInfrastructureServicesNpgsql()
            .AddInfrastructureDapperSqlMapperTypeHandlersNpgsql();
    }
}