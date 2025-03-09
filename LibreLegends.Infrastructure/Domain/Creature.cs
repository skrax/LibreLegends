using System.Text.Json;
using LibreLegends.Infrastructure.Schema;

namespace LibreLegends.Infrastructure.Domain;

public class Creature : Card
{
    public string? Description { get; set; }

    public required int Cost { get; set; }

    public required int Strength { get; set; }

    public required int Health { get; set; }

    public CreatureAbilities? Abilities { get; set; }

    internal static Creature FromTableRecord(CardTableRecord x, JsonSerializerOptions? serializerOptions = null) =>
        new()
        {
            Id = x.id,
            Name = x.name,
            Description = x.description,
            Cost = x.cost!.Value,
            Strength = x.strength!.Value,
            Health = x.health!.Value,
            Abilities = x.abilities is null
                ? null
                : JsonSerializer.Deserialize<CreatureAbilities>(x.abilities!, serializerOptions)
        };
}