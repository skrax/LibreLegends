using LibreLegends.CardManagement.Models.Request;
using LibreLegends.CardManagement.Models.Response;
using LibreLegends.Domain.Models.Cards;

namespace LibreLegends.CardManagement.Mapper;

public static class CardMapper
{
    public static CardResponse AsCardResponse(this Card card)
    {
        return card switch
        {
            Creature creature => creature.AsCreatureResponse(),
            Spell spell => spell.AsSpellResponse(),
            _ => throw new ArgumentOutOfRangeException(nameof(card))
        };
    }

    public static CreatureResponse AsCreatureResponse(this Creature card) => new()
    {
        Id = card.Id,
        Name = card.Name,
        FlavorText = card.FlavorText,
        Description = card.Description,
        Cost = card.Cost,
        Strength = card.Strength,
        Health = card.Health,
        Defender = card.Defender,
        Haste = card.Haste,
        Exposed = card.Exposed,
        BehaviorJson = card.Behavior?.ToJson(),
    };

    public static SpellResponse AsSpellResponse(this Spell spell) => new()
    {
        Id = spell.Id,
        Name = spell.Name,
        FlavorText = spell.FlavorText,
        Description = spell.Description,
        Cost = spell.Cost,
        BehaviorJson = spell.Behavior.ToJson()
    };

    public static Creature AsCreature(this CreateCreatureRequest request) => new()
    {
        Name = request.Name,
        FlavorText = request.FlavorText,
        Description = request.Description,
        Cost = request.Cost,
        Strength = request.Strength,
        Health = request.Health,
        Defender = request.Defender,
        Haste = request.Haste,
        Exposed = request.Exposed,
        Behavior = request.BehaviorJson is null ? null : CardBehavior.FromJson(request.BehaviorJson)
    };


    public static Creature AsCreature(this UpdateCreatureRequest request) => new()
    {
        Id = request.Id,
        Name = request.Name,
        FlavorText = request.FlavorText,
        Description = request.Description,
        Cost = request.Cost,
        Strength = request.Strength,
        Health = request.Health,
        Defender = request.Defender,
        Haste = request.Haste,
        Exposed = request.Exposed,
        Behavior = request.BehaviorJson is null ? null : CardBehavior.FromJson(request.BehaviorJson)
    };


    public static Spell AsSpell(this CreateSpellRequest request) => new()
    {
        Name = request.Name,
        FlavorText = request.FlavorText,
        Description = request.Description,
        Cost = request.Cost,
        Behavior = CardBehavior.FromJson(request.BehaviorJson)
    };

    public static Spell AsSpell(this UpdateSpellRequest request) => new()
    {
        Name = request.Name,
        FlavorText = request.FlavorText,
        Description = request.Description,
        Cost = request.Cost,
        Behavior = CardBehavior.FromJson(request.BehaviorJson)
    };
}