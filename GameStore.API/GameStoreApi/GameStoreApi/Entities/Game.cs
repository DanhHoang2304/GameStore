using System.ComponentModel.DataAnnotations;

namespace GameStoreApi.Entities;

public class Game
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public Genre? Genre { get; set; }

}
