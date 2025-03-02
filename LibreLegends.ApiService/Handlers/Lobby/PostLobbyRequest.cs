namespace LibreLegends.ApiService.Handlers.Lobby;

public readonly struct PostLobbyRequest
{
    public required string LobbyDescription { get; init; }
}