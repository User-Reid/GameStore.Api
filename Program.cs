using GameStore.Api.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

var gamesList = new List<GameDto>
{
  new GameDto(1, "Pokemon", "Adventure", 29.99, new DateOnly(1995, 7, 5)),
  new GameDto(2, "Final Fantasy XIV", "Adventure", 29.99, new DateOnly(2014, 7, 5)),
  new GameDto(3, "Magic The Gathering", "Adventure", 59.99, new DateOnly(1990, 7, 5)),
  new GameDto(4, "Marvel Rivals", "Hero-Shooter", 19.99, new DateOnly(1995, 7, 5)),
};

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());


//GET Game /games
app.MapGet("/games", () => gamesList);

app.Run();