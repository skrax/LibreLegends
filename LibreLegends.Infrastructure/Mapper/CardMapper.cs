using System.Text.Json;
using LibreLegends.Domain.Models;
using LibreLegends.Infrastructure.Schema;

namespace LibreLegends.Infrastructure.Mapper;

internal static class CardMapper
{
    internal static Creature AsCreature(this CardTableRecord x, JsonSerializerOptions? serializerOptions = null) =>
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

    internal static Spell AsSpell(this CardTableRecord x, JsonSerializerOptions? serializerOptions = null) => new()
    {
        Id = x.id,
        Name = x.name,
        Description = x.description!,
        Cost = x.cost!.Value,
        Abilities = JsonSerializer.Deserialize<SpellAbilities>(x.abilities!, serializerOptions)
    };

    internal static Card AsCard(this CardTableRecord x, JsonSerializerOptions? serializerOptions = null) =>
        (CardType)x.card_type_id switch
        {
            CardType.Creature => x.AsCreature(),
            CardType.Spell => x.AsSpell(),
            _ => throw new InvalidOperationException($"Unable to map from card type: {x.card_type_id}")
        };
}