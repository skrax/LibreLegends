﻿using Dapper;
using LibreLegends.Domain.Models;
using LibreLegends.Domain.Models.Cards;
using Npgsql;

namespace LibreLegends.Infrastructure.Stores;

internal class NpgsqlCreatureStore(NpgsqlConnection db) : ICreatureStore
{
    public async Task<Guid> AddAsync(Creature creature, CancellationToken cancellationToken = default)
    {
        await db.OpenAsync(cancellationToken);

        const string sql = """
                           INSERT INTO cards (name, description, card_type_id, cost, strength, health, behavior)
                           VALUES (@Name, @Description, 1, @Cost, @Strength, @Health, @Behavior)
                           RETURNING id
                           """;

        var parameters = new
        {
            creature.Name,
            creature.Description,
            creature.Cost,
            creature.Strength,
            creature.Health,
            creature.Behavior
        };

        var id = await db.ExecuteScalarAsync<Guid>(sql, parameters);

        await db.CloseAsync();

        creature.Id = id;
        return id;
    }

    public async Task<bool> UpdateAsync(Creature creature, CancellationToken cancellationToken = default)
    {
        await db.OpenAsync(cancellationToken);

        const string sql = """
                           UPDATE cards SET 
                               name = @Name,
                               description = @Description,
                               cost = @Cost,
                               strength = @Strength,
                               health = @Health,
                               behavior = @Behavior
                           WHERE id = @Id AND card_type_id = 1
                           """;

        var parameters = new
        {
            creature.Name,
            creature.Description,
            creature.Cost,
            creature.Strength,
            creature.Health,
            creature.Behavior,
            creature.Id
        };

        var rowsAffected = await db.ExecuteAsync(sql, parameters);

        await db.CloseAsync();

        return rowsAffected > 0;
    }
}