using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient
{
  private readonly Genre[] genres = 
  [
    new(){
      Id = 1,
      Name = "Sport"
    },
    new(){
      Id = 2,
      Name = "Fighting"
    },
    new(){
      Id = 3,
      Name = "Kid"
    },
    new(){
      Id = 4,
      Name = "Racing"
    },
    new(){
      Id = 5,
      Name = "Shooting"
    },
  ];

  public Genre[] GetGenres() => genres;
}
