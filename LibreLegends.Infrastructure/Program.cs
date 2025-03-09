using LibreLegends.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

builder.AddServiceDefaults();

builder.AddNpgsqlDataSource("libreLegendsDb");

builder.Services.AddHostedService<MigrateDatabase>();

builder.Build().Run();