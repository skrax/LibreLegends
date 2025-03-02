using LibreLegends.Game;

namespace LibreLegends.ApiService.Handlers.User;

public readonly ref struct PostUserHandler(UserService userService, PostUserRequest request) : IRequestHandler
{
    public IResult Execute()
    {
        var user = userService.Create(request.Name);

        return Results.CreatedAtRoute("users/{useId}", user);
    }
}