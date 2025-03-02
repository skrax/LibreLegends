using LibreLegends.ApiService.Handlers.Lobby;
using LibreLegends.ApiService.Handlers.User;
using LibreLegends.Game;
using Microsoft.AspNetCore.Mvc;

namespace LibreLegends.ApiService.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MapApplicationEndpoints(this WebApplication app)
    {
        return app
            .MapLobbies()
            .MapUsers();
    }

    private static WebApplication MapUsers(this WebApplication app)
    {
        app.MapGet("users", ([FromServices] UserService userService)
            => new GetUsersHandler(userService).Execute());

        app.MapGet("users/{id:guid}", ([FromServices] UserService userService, [FromRoute] Guid id)
            => new GetUserHandler(userService, id).Execute());

        app.MapPost("users", ([FromServices] UserService userService, [FromBody] PostUserRequest request)
            => new PostUserHandler(userService, request));

        app.MapDelete("users/{id:guid}", ([FromServices] UserService userService, [FromRoute] Guid id)
            => new DeleteUserHandler(userService, id).Execute());

        return app;
    }

    private static WebApplication MapLobbies(this WebApplication app)
    {
        app.MapGet("lobbies", ([FromServices] LobbyService lobbyService)
            => new GetLobbiesHandler(lobbyService).Execute());

        app.MapGet("lobbies/{id:guid}", ([FromRoute] Guid id, [FromServices] LobbyService lobbyService)
            => new GetLobbyHandler(lobbyService, id).Execute());

        app.MapPost("lobbies/{lobbyId:guid}/add-user", (
                [FromRoute] Guid lobbyId,
                [FromBody] PostLobbyAddUserRequest request,
                [FromServices] LobbyService lobbyService)
            => new PostLobbyAddUserHandler(lobbyService, lobbyId, request).Execute());

        app.MapPost("lobbies/{lobbyId:guid}/submit-deck", (
                [FromRoute] Guid lobbyId,
                [FromBody] PostLobbySubmitDeckRequest request,
                [FromServices] LobbyService lobbyService)
            => new PostLobbySubmitDeckHandler(lobbyService, lobbyId, request).Execute());

        app.MapPost("lobbies", ([FromBody] PostLobbyRequest request, [FromServices] LobbyService lobbyService)
            => new PostLobbyHandler(lobbyService, request).Execute());

        app.MapDelete("lobbies/{id:guid}", ([FromRoute] Guid id, [FromServices] LobbyService lobbyService)
            => new DeleteLobbyHandler(lobbyService, id).Execute());

        return app;
    }
}