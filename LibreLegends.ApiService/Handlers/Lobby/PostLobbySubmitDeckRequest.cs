namespace LibreLegends.ApiService.Handlers.Lobby;

public readonly struct PostLobbySubmitDeckRequest
{
    public required Guid UserId { get; init; }

    public required string DeckName { get; init; }
}