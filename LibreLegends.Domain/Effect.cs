using System.Text.Json.Serialization;

namespace LibreLegends.Domain;

[JsonDerivedType(typeof(DealDamageEffect), "dealDamageEffect")]
public abstract class Effect;