namespace LibreLegends.MatchMaking.Models.Request;

public class CreateMatchRequest
{
    public required string Name { get; set; }
    
    public required string PlayerName { get; set; }
}