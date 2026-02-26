using Gamestore.Api.DTOs;
{
  
}

const string GetGameEndpoint = "GetGame";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

var gamesList = new List<GameDto>
{
  new GameDto(1, "Pokemon", "Adventure", 29.99, new DateOnly(1995, 7, 5)),
  new GameDto(2, "Final Fantasy XIV", "Adventure", 29.99, new DateOnly(2014, 7, 5)),
  new GameDto(3, "Magic The Gathering", "Adventure", 59.99, new DateOnly(1990, 7, 5)),
  new GameDto(4, "Marvel Rivals", "Hero-Shooter", 19.99, new DateOnly(1995, 7, 5)),
};


//GET /games
app.MapGet("games", () => gamesList);

//GET /games/{id}
app.MapGet("games/{id}", (int id) =>
{
  var game = gamesList.Find((game) => game.Id == id);

  return game is null ? Results.NotFound() : Results.Ok(game);
}).WithName(GetGameEndpoint);


//POST /games
app.MapPost("games", (CreateGameDto gameUpdate) =>
{
  var game = new GameDto(
    gamesList.Count + 1,
    gameUpdate.Title,
    gameUpdate.Genre,
    gameUpdate.Price,
    gameUpdate.ReleaseDate
  );

  gamesList.Add(game);

  return Results.AcceptedAtRoute(GetGameEndpoint, new {Id = game.Id}, game);
});

//PUT /games/{id}
app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
{
  var index = gamesList.FindIndex((game) => game.Id == id);

  if(index < 0)
  {
    return Results.NotFound();
  }

  gamesList[index] = new GameDto (
    id,
    updatedGame.Title,
    updatedGame.Genre,
    updatedGame.Price,
    updatedGame.ReleaseDate
  );

  return gamesList[index] is null ? Results.NotFound() : Results.Ok();
});

//DELETE /games
app.MapDelete("games/{id}", (int id) =>
{
  gamesList.RemoveAll((game) => game.Id == id);

  return Results.Ok();
});

app.Run();