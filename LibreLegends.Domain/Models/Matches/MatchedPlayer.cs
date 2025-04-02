namespace LibreLegends.Domain.Models.Matches;

public class MatchedPlayer
{
    public required Guid Id { get; init; }
    
    public required string Name { get; set; }
    
    public required Guid Token { get; init; }
}