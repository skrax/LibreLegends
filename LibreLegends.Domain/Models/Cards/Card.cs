using System.Text.Json.Serialization;
using LibreLegends.Domain.Exceptions;

namespace LibreLegends.Domain.Models.Cards;

[JsonDerivedType(typeof(Creature))]
[JsonDerivedType(typeof(Spell))]
public abstract class Card
{
    private string _name;

    public Guid Id { get; set; }

    public string? FlavorText;

    public required string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyOrWhiteSpaceException(nameof(Name));
            }

            _name = value;
        }
    }
}