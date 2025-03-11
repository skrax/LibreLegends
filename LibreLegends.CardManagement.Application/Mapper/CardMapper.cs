using LibreLegends.CardManagement.Application.Models.Request;
using LibreLegends.CardManagement.Application.Models.Response;
using LibreLegends.Domain.Models;

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
        AbilitiesJson = card.GetAbilitiesAsJson(),
    };

    public static SpellResponse AsSpellResponse(this Spell spell) => new()
    {
        Id = spell.Id,
        Name = spell.Name,
        Description = spell.Description,
        Cost = spell.Cost,
        AbilitiesJson = spell.GetAbilitiesAsJson(),
    };

    public static Creature AsCreature(this CreateCreatureRequest request)
    {
        var creature = new Creature
        {
            Name = request.Name,
            Description = request.Description,
            Cost = request.Cost,
            Strength = request.Strength,
            Health = request.Health
        };

        if (request.AbilitiesJson is not null)
        {
            creature.SetAbilitiesAsJson(request.AbilitiesJson);
        }

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
            Health = request.Health
        };

        if (request.AbilitiesJson is not null)
        {
            creature.SetAbilitiesAsJson(request.AbilitiesJson);
        }

        return creature;
    }

    public static Spell AsSpell(this CreateSpellRequest request) => new()
    {
        Name = request.Name,
        Description = request.Description,
        Cost = request.Cost,
        Abilities = Spell.GetAbilitiesFromJson(request.AbilitiesJson)
    };

    public static Spell AsSpell(this UpdateSpellRequest request) => new()
    {
        Name = request.Name,
        Description = request.Description,
        Cost = request.Cost,
        Abilities = Spell.GetAbilitiesFromJson(request.AbilitiesJson)
    };
}