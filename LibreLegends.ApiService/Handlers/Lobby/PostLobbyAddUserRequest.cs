namespace LibreLegends.ApiService.Handlers.Lobby;

public readonly struct PostLobbyAddUserRequest
{
    public required Guid UserId { get; init; }
}