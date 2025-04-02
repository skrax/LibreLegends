using LibreLegends.Domain.Models.Matches;
using LibreLegends.MatchMaking.Models.Response;

namespace LibreLegends.MatchMaking.Mapper;

public static class MatchMapper
{
    public static MatchResponse AsMatchResponse(this Match match) => new MatchResponse
    {
        Id = match.Id,
        Name = match.Name,
        HostPlayerId = match.HostPlayerId!.Value,
        Players = match.Players.Select(AsMatchedPlayerResponse).ToArray()
    };

    private static MatchedPlayerResponse AsMatchedPlayerResponse(this MatchedPlayer matchedPlayer) => new MatchedPlayerResponse
    {
        Id = matchedPlayer.Id,
        Name = matchedPlayer.Name,
    };
}