namespace LibreLegends.CardManagement.Application.Models.Request;

public class CreateSpellRequest
{
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public required int Cost { get; set; }
    
    public required string BehaviorJson { get; set; }
}