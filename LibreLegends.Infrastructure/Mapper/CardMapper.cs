using System.Text.Json;
using LibreLegends.Domain.Models.Cards;
using LibreLegends.Infrastructure.Schema;

namespace LibreLegends.Infrastructure.Mapper;

internal static class CardMapper
{
    public static Creature AsCreature(this CardTableRecord x, JsonSerializerOptions? serializerOptions = null) =>
        new()
        {
            Id = x.id,
            Name = x.name,
            FlavorText = x.flavor_text,
            Description = x.description,
            Cost = x.cost!.Value,
            Strength = x.strength!.Value,
            Health = x.health!.Value,
            Defender = x.defender!.Value,
            Haste = x.haste!.Value,
            Exposed = x.exposed!.Value,
            Behavior = x.behavior is null
                ? null
                : CardBehavior.FromJson(x.behavior!, serializerOptions)
        };

    public static Spell AsSpell(this CardTableRecord x, JsonSerializerOptions? serializerOptions = null) => new()
    {
        Id = x.id,
        Name = x.name,
        FlavorText = x.flavor_text,
        Description = x.description!,
        Cost = x.cost!.Value,
        Behavior = CardBehavior.FromJson(x.behavior!, serializerOptions)
    };

    public static Card AsCard(this CardTableRecord x, JsonSerializerOptions? serializerOptions = null) =>
        (CardType)x.card_type_id switch
        {
            CardType.Creature => x.AsCreature(),
            CardType.Spell => x.AsSpell(),
            _ => throw new InvalidOperationException($"Unable to map from card type: {x.card_type_id}")
        };
}