namespace Gamestore.Api.DTOs;

public record UpdateGameDto (
  string Title,
  string Genre,
  double Price,
  DateOnly ReleaseDate
);