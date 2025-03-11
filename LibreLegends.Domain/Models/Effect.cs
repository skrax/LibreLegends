using System.Text.Json.Serialization;

namespace LibreLegends.Domain.Models;

[JsonDerivedType(typeof(DealDamageEffect), "dealDamageEffect")]
public abstract class Effect;