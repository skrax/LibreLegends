using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("Postgres")
    .WithEnvironment("POSTGRES_DB", "libre_legends")
    .WithPgAdmin()
    .WithDataVolume();

var database = postgres.AddDatabase("Database", databaseName: "libre_legends");

var databaseMigration = builder.AddProject<LibreLegends_DatabaseMigration>("DatabaseMigration")
    .WithReference(database);

databaseMigration.WaitFor(database);

var api = builder.AddProject<LibreLegends_Api>("Api").WithReference(database);

var frontend = builder.AddProject<LibreLegends_Web>("Web");

frontend.WaitFor(api);

builder.Build().Run();