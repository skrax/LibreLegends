using Dapper;
using LibreLegends.Infrastructure.Domain;
using LibreLegends.Infrastructure.Schema;
using Npgsql;

namespace LibreLegends.Infrastructure.Repositories;

internal class CardRepository(NpgsqlConnection connection) : ICardRepository
{
    public async Task<IReadOnlyList<Card>> GetCards()
    {
        await connection.OpenAsync();

        var records = await connection.QueryAsync<CardTableRecord>("select * from cards");

        await connection.CloseAsync();

        return records.Select(x => x.card_type_id switch
            {
                1 => Creature.FromTableRecord(x) as Card,
                2 => Spell.FromTableRecord(x),
                _ => throw new InvalidOperationException($"Unknown card type: {x.card_type_id}"),
            })
            .ToArray();
    }
}