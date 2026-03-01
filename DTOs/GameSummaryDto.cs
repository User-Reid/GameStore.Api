namespace Gamestore.Api.DTOs;

public record GameSummaryDto (
  int Id,
  string Title,
  string Genre,
  double Price,
  DateOnly ReleaseDate
);