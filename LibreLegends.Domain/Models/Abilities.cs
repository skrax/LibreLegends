using System.Text.Json.Serialization;

namespace LibreLegends.Domain.Models;

[JsonDerivedType(typeof(CreatureAbilities), "creatureAbilities")]
[JsonDerivedType(typeof(SpellAbilities), "spellAbilities")]
public abstract class Abilities;
