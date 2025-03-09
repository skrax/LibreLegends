using System.Text.Json.Serialization;

namespace LibreLegends.Infrastructure.Domain;

[JsonDerivedType(typeof(Creature))]
[JsonDerivedType(typeof(Spell))]
public abstract class Card
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }
}