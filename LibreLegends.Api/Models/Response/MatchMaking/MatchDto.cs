namespace LibreLegends.Api.Models.Response.MatchMaking;

public class MatchDto
{
    public required Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public required Guid HostPlayerId { get; set; }
    
    public required IReadOnlyCollection<MatchedPlayerDto> Players { get; set; }
}