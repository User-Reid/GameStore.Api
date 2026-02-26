using System.ComponentModel.DataAnnotations;

namespace Gamestore.Api.DTOs;

public record CreateGameDto (
  [Required] string Title,
  string Genre,
  double Price,
  DateOnly ReleaseDate
);