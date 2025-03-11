using Dapper;
using LibreLegends.Domain;
using Npgsql;

namespace LibreLegends.Infrastructure.Stores;

internal class NpgsqlSpellStore(NpgsqlConnection db) : ISpellStore
{
    public async Task<Guid> AddAsync(Spell spell, CancellationToken cancellationToken = default)
    {
        await db.OpenAsync(cancellationToken);

        const string sql = """
                           INSERT INTO cards (name, description, card_type_id, cost, abilities)
                           VALUES (@Name, @Description, 2, @Cost, @Abilities)
                           RETURNING id
                           """;

        var parameters = new
        {
            spell.Name,
            spell.Description,
            spell.Cost,
            spell.Abilities
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
                               cost = @Cost,
                               abilities = @Abilities
                           WHERE id = @Id AND card_type_id = 2
                           """;

        var parameters = new
        {
            spell.Name,
            spell.Description,
            spell.Cost,
            spell.Abilities,
            spell.Id
        };

        var rowsAffected = await db.ExecuteAsync(sql, parameters);

        await db.CloseAsync();

        return rowsAffected > 0;
    }
}