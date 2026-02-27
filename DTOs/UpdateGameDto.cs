using System.ComponentModel.DataAnnotations;

namespace Gamestore.Api.DTOs;

public record UpdateGameDto (
  [Required][StringLength(50)] string Title,
  [Required][StringLength(20)]string Genre,
  [Range(1, 100)]double Price,
  DateOnly ReleaseDate
);