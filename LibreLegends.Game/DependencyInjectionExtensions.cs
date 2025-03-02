using Microsoft.Extensions.DependencyInjection;

namespace LibreLegends.Game;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddLobbyService(this IServiceCollection services)
    {
        return services
            .AddSingleton<LobbyService>()
            .AddSingleton<MatchService>()
            .AddSingleton<UserService>();
    }
}