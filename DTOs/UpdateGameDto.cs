using System.ComponentModel.DataAnnotations;

namespace Gamestore.Api.DTOs;

public record UpdateGameDto (
  [Required][StringLength(50)] string Title,
  [Range(1, 50)]int GenreId,
  [Range(1, 100)]double Price,
  DateOnly ReleaseDate
);