using System.ComponentModel.DataAnnotations;

namespace LibreLegends.Api.Models.Request;

public class CreateOrUpdateSpellDto
{
    [MaxLength(50)]
    [RegularExpression(@"^[\p{L}\p{N}\s\-'\.\!\?\(\)]{3,50}$")]
    public required string Name { get; set; }

    [MaxLength(100)]
    [MinLength(3)]
    [RegularExpression(@"^[\p{L}\p{N}\s\-'\.\!\?\(\)]{3,100}$")]
    public string? FlavorText { get; set; }

    [MaxLength(100)]
    [RegularExpression(@"^[\p{L}\p{N}\s\-'\.\!\?\(\)]{3,100}$")]
    public required string Description { get; set; }

    [Range(0, int.MaxValue)] public required int Cost { get; set; }

    public required string BehaviorJson { get; set; }
}