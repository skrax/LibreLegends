namespace LibreLegends.Api.Models.Response.MatchMaking;

public class MatchedPlayerDto
{
    public required Guid Id { get; set; }
    
    public required string Name { get; set; }
}