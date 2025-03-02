using LibreLegends.Game;

namespace LibreLegends.ApiService.Handlers.Lobby;

public readonly ref struct GetLobbyHandler(LobbyService lobbyService, Guid lobbyId)
    : IRequestHandler
{
    public IResult Execute()
    {
        var lobby = lobbyService.Get(lobbyId);

        return lobby is null
            ? Results.NotFound()
            : Results.Ok(lobby);
    }
}