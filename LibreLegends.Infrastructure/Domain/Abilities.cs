using System.Text.Json.Serialization;

namespace LibreLegends.Infrastructure.Domain;

[JsonDerivedType(typeof(CreatureAbilities))]
[JsonDerivedType(typeof(SpellAbilities))]
public abstract class Abilities
{
    public int version { get; }
}