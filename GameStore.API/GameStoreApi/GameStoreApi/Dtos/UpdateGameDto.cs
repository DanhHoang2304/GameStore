using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.Dtos;

public record class UpdateGameDto
(
    [Required]
    [StringLength(50)]
    string Name,

    [Required]
    [StringLength(50)]
    string Genre,

    [Range(1,100)]
    decimal Price,

    DateOnly ReleaseDate
);