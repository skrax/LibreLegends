using LibreLegends.Game;

namespace LibreLegends.ApiService.Handlers.Lobby;

public readonly ref struct DeleteLobbyHandler(LobbyService lobbyService, Guid lobbyId) :IRequestHandler
{
    public IResult Execute()
    {
        lobbyService.Delete(lobbyId);

        return Results.NoContent();
    }
}