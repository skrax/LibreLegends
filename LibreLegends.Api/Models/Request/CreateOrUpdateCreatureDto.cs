using System.ComponentModel.DataAnnotations;

namespace LibreLegends.Api.Models.Request;

public class CreateOrUpdateCreatureDto
{
    [MaxLength(50)]
    [MinLength(3)]
    [RegularExpression(@"^[\p{L}\p{N}\s\-'\.\!\?\(\)]{3,50}$")]
    public required string Name { get; set; }
    
    [MaxLength(100)]
    [MinLength(3)]
    [RegularExpression(@"^[\p{L}\p{N}\s\-'\.\!\?\(\)]{3,100}$")]
    public string? FlavorText { get; set; }

    [MaxLength(100)]
    [MinLength(3)]
    [RegularExpression(@"^[\p{L}\p{N}\s\-'\.\!\?\(\)]{3,100}$")]
    public string? Description { get; set; }

    [Range(0, int.MaxValue)]
    public required int Cost { get; set; }

    [Range(0, int.MaxValue)]
    public required int Strength { get; set; }

    [Range(0, int.MaxValue)]
    public required int Health { get; set; }
    
    public bool Defender { get; set; }
    
    public bool Haste { get; set; }
    
    public bool Exposed { get; set; }
    
    public string? BehaviorJson { get; set; }
}