using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithEnvironment("POSTGRES_DB", "libre_legends")
    .WithPgAdmin()
    .WithDataVolume();

var database = postgres.AddDatabase("libreLegendsDb", databaseName: "libre_legends");

var databaseMigration = builder.AddProject<LibreLegends_Infrastructure>("libreLegendsDbMigration")
    .WithReference(database);

databaseMigration.WaitFor(database);

var api = builder.AddProject<LibreLegends_Api>("libreLegendsApi").WithReference(database);

var frontend = builder.AddProject<LibreLegends_Web>("libreLegendsWebClient");

frontend.WaitFor(api);

builder.Build().Run();