namespace LibreLegends.MatchMaking.Models.Response;

public class MatchResponse
{
    public required Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public required Guid HostPlayerId { get; set; }
    
    public Guid? PlayerToken { get; set; }
    
    public required IReadOnlyCollection<MatchedPlayerResponse> Players { get; set; }
}