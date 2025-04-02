namespace LibreLegends.Api.Models.Response.CardManagement;

public class CreatureDto : CardDto
{
    public required string? Description { get; set; }

    public required int Cost { get; set; }

    public required int Strength { get; set; }

    public required int Health { get; set; }
    
    public required bool Defender { get; set; }
    
    public required bool Haste { get; set; }
    
    public required bool Exposed { get; set; }

    public string? BehaviorJson { get; set; }
}