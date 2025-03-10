using System.Text.Json.Serialization;

namespace LibreLegends.Infrastructure.Domain;

[JsonDerivedType(typeof(SingleTargeting), "single")]
[JsonDerivedType(typeof(MultiTargeting), "multi")]
[JsonDerivedType(typeof(AoeTargeting), "aoe")]
public abstract class Targeting;