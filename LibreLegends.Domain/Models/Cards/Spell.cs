using System.Text.Json;
using LibreLegends.Domain.Exceptions;

namespace LibreLegends.Domain.Models.Cards;

public class Spell : Card
{
    private int _cost;
    private string _description;

    public required string Description
    {
        get => _description;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyOrWhiteSpaceException(nameof(Description));
            }

            _description = value;
        }
    }

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

    public required CardBehavior Behavior { get; set; }
}