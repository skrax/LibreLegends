using System.Text.Json.Serialization;

namespace LibreLegends.Infrastructure.Domain;

[JsonDerivedType(typeof(CreatureAbilities), "creatureAbilities")]
[JsonDerivedType(typeof(SpellAbilities), "spellAbilities")]
public abstract class Abilities;
