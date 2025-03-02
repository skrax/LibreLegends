using LibreLegends.Game;

namespace LibreLegends.ApiService.Handlers.User;

public readonly ref struct DeleteUserHandler(UserService userService, Guid userId) : IRequestHandler
{
    public IResult Execute()
    {
        userService.Delete(userId);

        return Results.NoContent();
    }
}