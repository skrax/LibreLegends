namespace LibreLegends.CardManagement.Models.Request;

public class UpdateCreatureRequest
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }
    
    public string? FlavorText { get; set; }

    public string? Description { get; set; }

    public required int Cost { get; set; }

    public required int Strength { get; set; }

    public required int Health { get; set; }
    
    public bool Defender { get; set; }
    
    public bool Haste { get; set; }
    
    public bool Exposed { get; set; }
    
    public string? BehaviorJson { get; set; }
}