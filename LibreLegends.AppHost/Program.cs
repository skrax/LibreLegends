var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.LibreLegends_ApiService>("apiservice");

var swaggerUi = builder
    .AddContainer("swagger-ui", "docker.swagger.io/swaggerapi/swagger-ui", "latest")
    .WithHttpEndpoint(targetPort: 8080)
    .WithEnvironment("SWAGGER_JSON_URL", "https://localhost:7507/openapi/v1.json");

builder.AddProject<Projects.LibreLegends_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();