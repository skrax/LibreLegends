using System.Text.Json.Serialization;

namespace LibreLegends.Infrastructure.Domain;

[JsonDerivedType(typeof(DealDamageEffect), "dealDamageEffect")]
public abstract class Effect;