using LibreLegends.Api.Models.Response.MatchMaking;
using LibreLegends.MatchMaking.Models.Response;

namespace LibreLegends.Api.Mapper.MatchMaking;

public static class MatchDtoMapper
{
    public static MatchDto AsMatchDto(this MatchResponse matchResponse) => new()
    {
        Id = matchResponse.Id,
        Name = matchResponse.Name,
        HostPlayerId = matchResponse.HostPlayerId,
        Players = matchResponse.Players.Select(AsMatchedPlayerDto).ToArray()
    };

    private static MatchedPlayerDto AsMatchedPlayerDto(this MatchedPlayerResponse matchedPlayerResponse) => new()
    {
        Id = matchedPlayerResponse.Id,
        Name = matchedPlayerResponse.Name,
    };
}