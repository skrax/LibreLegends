namespace LibreLegends.Api.Models.Request.MatchMaking;

public class CreateMatchDto
{
    public required string Name { get; set; }
    
    public required string PlayerName { get; set; }
}