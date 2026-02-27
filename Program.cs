using Gamestore.Api.Data;
using Gamestore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddValidation();

var connString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapGamesEndpoints();

app.Run();