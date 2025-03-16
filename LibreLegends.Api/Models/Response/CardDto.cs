using System.Text.Json.Serialization;

namespace LibreLegends.Api.Models.Response;

[JsonDerivedType(typeof(CreatureDto), "creature")]
[JsonDerivedType(typeof(SpellDto), "spell")]
public abstract class CardDto
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }
    
    public required string? FlavorText { get; set; }
}