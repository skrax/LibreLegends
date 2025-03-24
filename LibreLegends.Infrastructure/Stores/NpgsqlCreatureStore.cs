using Dapper;
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
                           INSERT INTO cards (
                               name,
                               description,
                               flavor_text,
                               card_type_id,
                               cost,
                               strength,
                               health,
                               defender,
                               haste,
                               exposed,
                               behavior
                           )
                           VALUES (
                               @Name, 
                               @Description,
                               @FlavorText,
                               1,
                               @Cost,
                               @Strength,
                               @Health,
                               @Defender,
                               @Haste,
                               @Exposed,
                               @Behavior
                           )
                           RETURNING id
                           """;

        var parameters = new
        {
            creature.Name,
            creature.Description,
            creature.FlavorText,
            creature.Cost,
            creature.Strength,
            creature.Health,
            creature.Defender,
            creature.Haste,
            creature.Exposed,
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
                               flavor_text = @FlavorText,
                               cost = @Cost,
                               strength = @Strength,
                               health = @Health,
                               defender = @Defender,
                               haste = @Haste,
                               exposed = @Exposed,
                               behavior = @Behavior
                           WHERE id = @Id AND card_type_id = 1
                           """;

        var parameters = new
        {
            creature.Name,
            creature.Description,
            creature.FlavorText,
            creature.Cost,
            creature.Strength,
            creature.Health,
            creature.Defender,
            creature.Haste,
            creature.Exposed,
            creature.Behavior,
            creature.Id
        };

        var rowsAffected = await db.ExecuteAsync(sql, parameters);

        await db.CloseAsync();

        return rowsAffected > 0;
    }
}