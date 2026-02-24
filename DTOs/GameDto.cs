namespace GameStore.Api.DTOs;

public record GameDto (
  int Id,
  string Title,
  string Genre,
  double Price,
  DateOnly ReleaseDate
);