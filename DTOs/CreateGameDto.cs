namespace Gamestore.Api.DTOs;

public record CreateGameDto (
  string Title,
  string Genre,
  double Price,
  DateOnly ReleaseDate
);