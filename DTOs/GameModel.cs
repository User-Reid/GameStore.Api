namespace GameStore.Api.Dtos;

public record GameDetailsDto (
  int Id,
  string Title,
  int GenreId,
  double Price,
  DateOnly ReleaseDate
);