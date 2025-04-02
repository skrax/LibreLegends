using LibreLegends.MatchMaking.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibreLegends.MatchMaking.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddMatchMaking(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMatchMakingService, MatchMakingService>();
        
        return builder;
    }
}