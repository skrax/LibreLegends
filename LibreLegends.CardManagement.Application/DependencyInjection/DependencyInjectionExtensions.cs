using LibreLegends.CardManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibreLegends.CardManagement.Application.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddCardManagement(this IHostApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<ICardManagementService, CardManagementService>();

        return builder;
    }
}