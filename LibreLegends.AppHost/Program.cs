using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithPgAdmin()
    .WithDataVolume();

var database = postgres.AddDatabase("libreLegendsDb", databaseName: "libre_legends");

var databaseMigration = builder.AddProject<LibreLegends_Infrastructure>("libreLegendsDbMigration")
    .WithReference(database);

databaseMigration.WaitFor(database);

var api = builder.AddProject<LibreLegends_Api>("libreLegendsApi").WithReference(database);

builder.Build().Run();