using System.Text.Json;
using LibreLegends.Domain.Exceptions;

namespace LibreLegends.Domain.Models.Cards;

public class Creature : Card
{
    private int _cost;

    private int _strength;

    private int _health;
    public string? Description { get; set; }

    public required int Cost
    {
        get => _cost;

        set
        {
            if (value < 0)
            {
                throw new NegativeStatException(nameof(Cost));
            }

            _cost = value;
        }
    }

    public required int Strength
    {
        get => _strength;

        set
        {
            if (value < 0)
            {
                throw new NegativeStatException(nameof(Strength));
            }

            _strength = value;
        }
    }

    public required int Health
    {
        get => _health;

        set
        {
            if (value < 0)
            {
                throw new NegativeStatException(nameof(Health));
            }

            _health = value;
        }
    }
    
    public required bool Defender { get; set; }
    
    public required bool Haste { get; set; }
    
    public required bool Exposed { get; set; }

    public CardBehavior? Behavior { get; set; }
}