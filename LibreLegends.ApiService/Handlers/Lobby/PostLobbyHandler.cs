using LibreLegends.Game;

namespace LibreLegends.ApiService.Handlers.Lobby;

public readonly ref struct PostLobbyHandler(LobbyService lobbyService, PostLobbyRequest request)
    : IRequestHandler
{
    public IResult Execute()
    {
        var lobby = lobbyService.Create(request.LobbyDescription);

        return Results.CreatedAtRoute("lobbies/{lobbyId}", lobby.Id, lobby);
    }
}