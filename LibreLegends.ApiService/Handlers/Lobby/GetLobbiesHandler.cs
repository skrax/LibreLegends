using LibreLegends.Game;

namespace LibreLegends.ApiService.Handlers.Lobby;

public readonly ref struct GetLobbiesHandler(LobbyService lobbyService)
    : IRequestHandler
{
    public IResult Execute()
    {
        var lobbies = lobbyService.Get();

        return Results.Ok(lobbies);
    }
}