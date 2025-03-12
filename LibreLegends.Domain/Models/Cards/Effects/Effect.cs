using System.Text.Json.Serialization;

namespace LibreLegends.Domain.Models.Cards.Effects;

[JsonDerivedType(typeof(DealDamageEffect), "dealDamageEffect")]
public abstract class Effect;