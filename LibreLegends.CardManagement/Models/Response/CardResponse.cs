namespace LibreLegends.CardManagement.Models.Response;

public class CardResponse
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }
    
    public required string? FlavorText { get; set; }
}