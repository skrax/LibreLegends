using System.Text.Json;
using Dapper;
using LibreLegends.Infrastructure.Domain;
using LibreLegends.Infrastructure.Schema;
using Npgsql;

namespace LibreLegends.Infrastructure.Repositories;

internal class CardRepository(NpgsqlConnection connection) : ICardRepository
{
    private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public async Task<IReadOnlyList<Card>> GetCards()
    {
        await connection.OpenAsync();

        var records = await connection.QueryAsync<CardTableRecord>("SELECT * FROM cards");

        await connection.CloseAsync();

        return records.Select(MapToCard).ToArray();
    }

    public async Task<Card?> GetCardById(Guid id)
    {
        await connection.OpenAsync();

        var record = await connection.QuerySingleOrDefaultAsync<CardTableRecord>(
            "SELECT * FROM cards WHERE id = @Id", new { Id = id });

        await connection.CloseAsync();

        return record != null ? MapToCard(record) : null;
    }

    public async Task<IReadOnlyList<Card>> GetCardsByType(int cardTypeId)
    {
        await connection.OpenAsync();

        var records = await connection.QueryAsync<CardTableRecord>(
            "SELECT * FROM cards WHERE card_type_id = @CardTypeId", new { CardTypeId = cardTypeId });

        await connection.CloseAsync();

        return records.Select(MapToCard).ToArray();
    }

    public async Task<Guid> CreateCard(Card card)
    {
        await connection.OpenAsync();

        var id = card switch
        {
            Creature creature => await connection.ExecuteScalarAsync<Guid>(
                """
                                    INSERT INTO cards (name, description, card_type_id, cost, strength, health, abilities)
                                    VALUES (@Name, @Description, 1, @Cost, @Strength, @Health, @Abilities)
                                    RETURNING id
                """,
                new
                {
                    creature.Name,
                    creature.Description,
                    creature.Cost,
                    creature.Strength,
                    creature.Health,
                    creature.Abilities
                }
            ),
            Spell spell => await connection.ExecuteScalarAsync<Guid>(
                """
                                        INSERT INTO cards (name, description, card_type_id, cost, abilities)
                                        VALUES (@Name, @Description, 2, @Cost, @Abilities)
                                        RETURNING id
                """,
                new
                {
                    spell.Name,
                    spell.Description,
                    spell.Cost,
                    spell.Abilities
                }
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(card), "Unsupported card type")
        };

        await connection.CloseAsync();

        return id;
    }

    public async Task<bool> UpdateCard(Card card)
    {
        await connection.OpenAsync();

        var rowsAffected = card switch
        {
            Creature creature => await connection.ExecuteAsync(
                """
                    UPDATE cards 
                    SET name = @Name,
                    description = @Description,
                    cost = @Cost,
                    strength = @Strength,
                    health = @Health,
                    abilities = @Abilities
                    WHERE id = @Id AND card_type_id = 1
                """,
                new
                {
                    creature.Name,
                    creature.Description,
                    creature.Cost,
                    creature.Strength,
                    creature.Health,
                    creature.Abilities,
                    creature.Id
                }
            ),

            Spell spell =>
                await connection.ExecuteAsync(
                    """
                    UPDATE cards
                    SET name = @Name,
                        description = @Description,
                        cost = @Cost,
                        abilities = @Abilities
                    WHERE id = @Id AND card_type_id = 2
                    """,
                    new
                    {
                        spell.Name,
                        spell.Description,
                        spell.Cost,
                        spell.Abilities,
                        spell.Id
                    }
                ),
            _ => throw new ArgumentOutOfRangeException(nameof(card), "Unsupported card type")
        };

        await connection.CloseAsync();

        return rowsAffected > 0;
    }

    public async Task<bool> DeleteCard(Guid id)
    {
        await connection.OpenAsync();

        var rowsAffected = await connection.ExecuteAsync(
            "DELETE FROM cards WHERE id = @Id", new { Id = id });

        await connection.CloseAsync();

        return rowsAffected > 0;
    }

    public async Task Delete()
    {
        await connection.OpenAsync();
        
        var rowsAffected = await connection.ExecuteAsync("DELETE FROM cards");
        
        await connection.CloseAsync();
    }

    private Card MapToCard(CardTableRecord record)
    {
        return record.card_type_id switch
        {
            1 => Creature.FromTableRecord(record, _jsonOptions) as Card,
            2 => Spell.FromTableRecord(record, _jsonOptions),
            _ => throw new InvalidOperationException($"Unknown card type: {record.card_type_id}")
        };
    }
}