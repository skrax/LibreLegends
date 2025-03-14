using LibreLegends.Infrastructure;
using LibreLegends.Infrastructure.DependencyInjection;
using LibreLegends.ServiceDefaults;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

builder.AddServiceDefaults();

builder.AddInfrastructureDatabaseNpgsql();

builder.Services.AddHostedService<MigrateDatabase>();

builder.Build().Run();