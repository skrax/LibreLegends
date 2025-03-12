using System.ComponentModel.DataAnnotations;

namespace LibreLegends.Api.Models.Request;

public class CreateOrUpdateCreatureDto
{
    [MaxLength(50)]
    [RegularExpression(@"^[\p{L}\p{N}\s\-'\.\!\?\(\)]{3,50}$")]
    public required string Name { get; set; }

    [MaxLength(100)]
    [RegularExpression(@"^[\p{L}\p{N}\s\-'\.\!\?\(\)]{3,100}$")]
    public string? Description { get; set; }

    [Range(0, int.MaxValue)]
    public required int Cost { get; set; }

    [Range(0, int.MaxValue)]
    public required int Strength { get; set; }

    [Range(0, int.MaxValue)]
    public required int Health { get; set; }
    
    public string? BehaviorJson { get; set; }
}