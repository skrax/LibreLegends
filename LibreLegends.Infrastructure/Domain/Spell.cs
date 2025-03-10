using System.Text.Json;
using LibreLegends.Infrastructure.Schema;

namespace LibreLegends.Infrastructure.Domain;

public class Spell : Card
{
    public required string Description { get; set; }

    public int Cost { get; set; }

    public required SpellAbilities? Abilities { get; set; }

    internal static Spell FromTableRecord(CardTableRecord x, JsonSerializerOptions? serializerOptions = null) => new()
    {
        Id = x.id,
        Name = x.name,
        Description = x.description!,
        Cost = x.cost!.Value,
        Abilities = JsonSerializer.Deserialize<SpellAbilities>(x.abilities!, serializerOptions)
    };
}