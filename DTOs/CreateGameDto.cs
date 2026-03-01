using System.ComponentModel.DataAnnotations;

namespace Gamestore.Api.DTOs;

public record CreateGameDto (
  [Required][StringLength(50)] string Title,
  [Range(1, 50)]int GenreId,
  [Range(1, 200)]double Price,
  DateOnly ReleaseDate
);