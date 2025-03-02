namespace LibreLegends.ApiService.Handlers.User;

public readonly struct PostUserRequest
{
    public required string Name { get; init; }
}