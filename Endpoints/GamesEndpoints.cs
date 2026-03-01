namespace Gamestore.Api.Endpoints;

using Gamestore.Api.Data;
using Gamestore.Api.DTOs;
using Gamestore.Api.Models;
using GameStore.Api.Dtos;

public static class GamesEndpoints {
  private const string GetGameEndpoint = "GetGame";
  private readonly static List<GameDto> gamesList = 
[
  new GameDto(1, "Pokemon", "Adventure", 29.99, new DateOnly(1995, 7, 5)),
  new GameDto(2, "Final Fantasy XIV", "Adventure", 29.99, new DateOnly(2014, 7, 5)),
  new GameDto(3, "Magic The Gathering", "Adventure", 59.99, new DateOnly(1990, 7, 5)),
  new GameDto(4, "Marvel Rivals", "Hero-Shooter", 19.99, new DateOnly(1995, 7, 5)),
];

  public static void MapGamesEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("/games");

    //GET /games
group.MapGet("/", () => gamesList);

//GET /games/{id}
group.MapGet("/{id}", (int id) =>
{
  var game = gamesList.Find((game) => game.Id == id);

  return game is null ? Results.NotFound() : Results.Ok(game);
}).WithName(GetGameEndpoint);


//POST /games
group.MapPost("/", (CreateGameDto createdGame, GameStoreContext dbContext) =>
{
  Game game = new()
  {
    Title = createdGame.Title,
    GenreId = createdGame.GenreId,
    Price = createdGame.Price,
    ReleaseDate = createdGame.ReleaseDate
  };

  dbContext.Games.Add(game);
  dbContext.SaveChanges();

  GameDetailsDto gameDto = new(
    game.Id,
    game.Title,
    game.GenreId,
    game.Price,
    game.ReleaseDate
  );

  return Results.AcceptedAtRoute(GetGameEndpoint, new {id = gameDto.Id}, gameDto);
});

//PUT /games/{id}
group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
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
group.MapDelete("/{id}", (int id) =>
{
  gamesList.RemoveAll((game) => game.Id == id);

  return Results.Ok();
});
  }
}