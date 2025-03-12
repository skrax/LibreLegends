using LibreLegends.CardManagement.Application.Models.Request;
using LibreLegends.CardManagement.Application.Models.Response;
using LibreLegends.Domain.Models.Cards;

namespace LibreLegends.CardManagement.Application.Mapper;

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
        Description = card.Description,
        Cost = card.Cost,
        Strength = card.Strength,
        Health = card.Health,
        BehaviorJson = card.Behavior?.ToJson()
    };

    public static SpellResponse AsSpellResponse(this Spell spell) => new()
    {
        Id = spell.Id,
        Name = spell.Name,
        Description = spell.Description,
        Cost = spell.Cost,
        BehaviorJson = spell.Behavior.ToJson()
    };

    public static Creature AsCreature(this CreateCreatureRequest request)
    {
        var creature = new Creature
        {
            Name = request.Name,
            Description = request.Description,
            Cost = request.Cost,
            Strength = request.Strength,
            Health = request.Health,
            Behavior = request.BehaviorJson is null ? null : CardBehavior.FromJson(request.BehaviorJson)
        };

        return creature;
    }

    public static Creature AsCreature(this UpdateCreatureRequest request)
    {
        var creature = new Creature
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Cost = request.Cost,
            Strength = request.Strength,
            Health = request.Health,
            Behavior = request.BehaviorJson is null ? null : CardBehavior.FromJson(request.BehaviorJson)
        };

        return creature;
    }

    public static Spell AsSpell(this CreateSpellRequest request) => new()
    {
        Name = request.Name,
        Description = request.Description,
        Cost = request.Cost,
        Behavior = CardBehavior.FromJson(request.BehaviorJson)
    };

    public static Spell AsSpell(this UpdateSpellRequest request) => new()
    {
        Name = request.Name,
        Description = request.Description,
        Cost = request.Cost,
        Behavior = CardBehavior.FromJson(request.BehaviorJson)
    };
}