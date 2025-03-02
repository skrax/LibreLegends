using LibreLegends.Game;

namespace LibreLegends.ApiService.Handlers.User;

public readonly ref struct GetUsersHandler(UserService userService) : IRequestHandler
{
    public IResult Execute()
    {
        var users = userService.Get();

        return Results.Ok(users);
    }
}