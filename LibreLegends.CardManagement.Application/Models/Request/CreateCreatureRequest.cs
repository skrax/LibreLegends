namespace LibreLegends.CardManagement.Application.Models.Request;

public class CreateCreatureRequest
{
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public required int Cost { get; set; }
    
    public required int Strength { get; set; }
    
    public required int Health { get; set; }
    
    public string? BehaviorJson { get; set; }
}