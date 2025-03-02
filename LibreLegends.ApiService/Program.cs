using LibreLegends.ApiService.Extensions;
using LibreLegends.Game;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors();

builder.Services.AddLobbyService();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}

app.MapApplicationEndpoints();

app.MapDefaultEndpoints();

app.Run();