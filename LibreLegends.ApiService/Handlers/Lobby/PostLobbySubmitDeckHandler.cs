using LibreLegends.Game;

namespace LibreLegends.ApiService.Handlers.Lobby;

public readonly ref struct PostLobbySubmitDeckHandler(
    LobbyService lobbyService,
    Guid lobbyId,
    PostLobbySubmitDeckRequest request) : IRequestHandler
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
            lobbyService.SubmitDeck(lobbyId, request.UserId, request.DeckName);

            return Results.Ok();
        }
        catch (InvalidOperationException e)
        {
            return Results.BadRequest(e.Message);
        }
    }
}