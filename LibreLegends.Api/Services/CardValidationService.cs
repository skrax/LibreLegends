using LibreLegends.Infrastructure.Domain;

namespace LibreLegends.Api.Services;

public class CardValidationService : ICardValidationService
{
    public (bool IsValid, string? ErrorMessage) ValidateCard(Card card)
    {
        if (string.IsNullOrWhiteSpace(card.Name))
        {
            return (false, "Card name is required");
        }

        if (card.Name.Length > 100)
        {
            return (false, "Card name must be 100 characters or less");
        }

        switch (card)
        {
            case Creature creature:
                return ValidateCreature(creature);
            case Spell spell:
                return ValidateSpell(spell);
            default:
                return (false, "Unsupported card type");
        }
    }

    private (bool IsValid, string? ErrorMessage) ValidateCreature(Creature creature)
    {
        if (creature.Cost < 0)
        {
            return (false, "Creature cost cannot be negative");
        }

        if (creature.Strength < 0)
        {
            return (false, "Creature strength cannot be negative");
        }

        if (creature.Health <= 0)
        {
            return (false, "Creature health must be greater than zero");
        }

        return (true, null);
    }

    private (bool IsValid, string? ErrorMessage) ValidateSpell(Spell spell)
    {
        if (string.IsNullOrWhiteSpace(spell.Description))
        {
            return (false, "Spell description is required");
        }

        if (spell.Cost < 0)
        {
            return (false, "Spell cost cannot be negative");
        }

        if (spell.Abilities == null)
        {
            return (false, "Spell must have abilities defined");
        }

        return (true, null);
    }
}