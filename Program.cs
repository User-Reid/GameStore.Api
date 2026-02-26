using Gamestore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddValidation();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapGamesEndpoints();

app.Run();