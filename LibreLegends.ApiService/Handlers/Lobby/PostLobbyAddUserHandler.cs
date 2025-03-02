using LibreLegends.Game;

namespace LibreLegends.ApiService.Handlers.Lobby;

public readonly ref struct PostLobbyAddUserHandler(
    LobbyService lobbyService,
    Guid lobbyId,
    PostLobbyAddUserRequest request)
    : IRequestHandler
{
    public IResult Execute()
    {
        var lobby = lobbyService.Get(lobbyId);

        if (lobby is null)
        {
            return Results.NotFound();
        }

        try
        {
            lobbyService.AddUser(lobbyId, request.UserId);

            return Results.Ok();
        }
        catch (InvalidOperationException e)
        {
            return Results.BadRequest(e.Message);
        }
    }
}