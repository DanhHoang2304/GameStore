using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.Entities;

public class Genre
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
}
