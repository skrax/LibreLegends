using Dapper;
using LibreLegends.Domain.Models;
using LibreLegends.Infrastructure.Mapper;
using LibreLegends.Infrastructure.Schema;
using Npgsql;

namespace LibreLegends.Infrastructure.Stores;

public class NpgsqlCardStore(ICreatureStore creatureStore, ISpellStore spellStore, NpgsqlConnection db)
    : ICardStore
{
    public async Task<IReadOnlyList<Card>> GetAsync(CancellationToken cancellationToken = default)
    {
        await db.OpenAsync(cancellationToken);

        const string sql = "SELECT * FROM cards";

        var records = await db.QueryAsync<CardTableRecord>(sql);

        await db.CloseAsync();

        return records
            .Select(x => x.AsCard())
            .ToArray();
    }

    public async Task<Card?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await db.OpenAsync(cancellationToken);

        const string sql = "SELECT * FROM cards WHERE id = @id";

        var parameters = new { id };

        var record = await db.QuerySingleOrDefaultAsync<CardTableRecord>(sql, parameters);

        await db.CloseAsync();

        return record?.AsCard();
    }

    public async Task<IReadOnlyList<Card>> GetAsync(CardType cardType, CancellationToken cancellationToken = default)
    {
        await db.OpenAsync(cancellationToken);

        const string sql = "SELECT * FROM cards WHERE card_type_id = @cardType";

        var parameters = new { cardType = (int)cardType };

        var records = await db.QueryAsync<CardTableRecord>(sql, parameters);

        await db.CloseAsync();

        return records
            .Select(x => x.AsCard())
            .ToArray();
    }

    public Task<Guid> AddAsync(Card card, CancellationToken cancellationToken = default)
    {
        return card switch
        {
            Creature creature => creatureStore.AddAsync(creature, cancellationToken),
            Spell spell => spellStore.AddAsync(spell, cancellationToken),
            _ => throw new ArgumentOutOfRangeException(nameof(card))
        };
    }

    public Task<bool> UpdateAsync(Card card, CancellationToken cancellationToken = default)
    {
        return card switch
        {
            Creature creature => creatureStore.UpdateAsync(creature, cancellationToken),
            Spell spell => spellStore.UpdateAsync(spell, cancellationToken),
            _ => throw new ArgumentOutOfRangeException(nameof(card))
        };
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await db.OpenAsync(cancellationToken);

        const string sql = "DELETE FROM cards WHERE id = @id";

        var parameters = new { id };

        var rowsAffected = await db.ExecuteAsync(sql, parameters);

        await db.CloseAsync();
        
        return rowsAffected is 1;
    }

    public async Task DeleteAsync(CancellationToken cancellationToken = default)
    {
        await db.OpenAsync(cancellationToken);

        const string sql = "DELETE FROM cards";

        await db.ExecuteAsync(sql);

        await db.CloseAsync();
    }
}