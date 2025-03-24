using Dapper;
using LibreLegends.Domain.Models;
using LibreLegends.Domain.Models.Cards;
using Npgsql;

namespace LibreLegends.Infrastructure.Stores;

internal class NpgsqlSpellStore(NpgsqlConnection db) : ISpellStore
{
    public async Task<Guid> AddAsync(Spell spell, CancellationToken cancellationToken = default)
    {
        await db.OpenAsync(cancellationToken);

        const string sql = """
                           INSERT INTO cards (
                               name,
                               description,
                               flavor_text,
                               card_type_id,
                               cost,
                               behavior
                           )
                           VALUES (
                               @Name,
                               @Description,
                               @FlavorText,
                               2,
                               @Cost,
                               @Behavior
                           )
                           RETURNING id
                           """;

        var parameters = new
        {
            spell.Name,
            spell.Description,
            spell.FlavorText,
            spell.Cost,
            spell.Behavior
        };

        var id = await db.ExecuteScalarAsync<Guid>(sql, parameters);

        await db.CloseAsync();

        spell.Id = id;

        return id;
    }

    public async Task<bool> UpdateAsync(Spell spell, CancellationToken cancellationToken = default)
    {
        await db.OpenAsync(cancellationToken);

        const string sql = """
                           UPDATE cards SET 
                               name = @Name,
                               description = @Description,
                               flavor_text = @FlavorText,
                               cost = @Cost,
                               behavior = @Behavior
                           WHERE id = @Id AND card_type_id = 2
                           """;

        var parameters = new
        {
            spell.Name,
            spell.Description,
            spell.FlavorText,
            spell.Cost,
            spell.Behavior,
            spell.Id
        };

        var rowsAffected = await db.ExecuteAsync(sql, parameters);

        await db.CloseAsync();

        return rowsAffected > 0;
    }
}