namespace GameStore.Api.DTOs;

public record CreateGameDto(
  string Name,
  string Genre,
  double Price,
  DateOnly ReleaseDate
);