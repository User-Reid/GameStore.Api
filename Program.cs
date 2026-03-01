using Gamestore.Api.Endpoints;
using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddValidation();

builder.AddGameStoreDb();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapGamesEndpoints();
app.MapGenresEndpoints();

app.MigrateDb();

app.Run();