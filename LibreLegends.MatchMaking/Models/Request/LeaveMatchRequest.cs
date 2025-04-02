namespace LibreLegends.MatchMaking.Models.Request;

public class LeaveMatchRequest
{
    public required Guid MatchId { get; set; }
    
    public required Guid PlayerToken { get; set; }
}