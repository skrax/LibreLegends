using LibreLegends.Game;

namespace LibreLegends.ApiService.Handlers.User;

public readonly ref struct GetUserHandler(UserService userService, Guid userId) : IRequestHandler
{
    public IResult Execute()
    {
        var user = userService.Get(userId);

        return user is null
            ? Results.NotFound()
            : Results.Ok(user);
    }
}