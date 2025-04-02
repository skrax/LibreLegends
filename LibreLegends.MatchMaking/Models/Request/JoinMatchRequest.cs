namespace LibreLegends.MatchMaking.Models.Request;

public class JoinMatchRequest
{
    public required Guid MatchId { get; set; }
    
    public required string PlayerName { get; set; }
}