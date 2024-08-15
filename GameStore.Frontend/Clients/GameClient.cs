using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GameClient
{
  private readonly List<GameSummary> games = 
  [
    new(){
      Id = 1,
      Name = "FIFA 24",
      Genre = "Sport",
      Price = 10.10M,
      ReleaseDate = new DateOnly(2024, 1, 1)
      },

    new(){
      Id = 2,
      Name = "Valorant",
      Genre = "Shooting",
      Price = 12.10M,
      ReleaseDate = new DateOnly(2020, 1, 1)
    },

    new(){
      Id = 3,
      Name = "Bird",
      Genre = "Kid",
      Price = 1.10M,
      ReleaseDate = new DateOnly(2015, 1, 1) }
  ];

  private readonly Genre[] genres = new GenresClient().GetGenres();

  public GameSummary[] GetGames() => [.. games];

  public void AddGame(GameDetails game)
    {
        Genre genre = GetGerneById(game.GenreId);

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }

  public GameDetails GetGame(int id)
    {
        GameSummary? game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(
          genre.Name,
          game.Genre,
          StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
      var genre = GetGerneById(updatedGame.GenreId);
      GameSummary existingGame = GetGameSummaryById(updatedGame.Id);
      
      //Update Game
      existingGame.Name = updatedGame.Name;
      existingGame.Genre = genre.Name;
      existingGame.Price = updatedGame.Price;
      existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
      var game = GetGameSummaryById(id);
      games.Remove(game);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGerneById(string? id)
  {
      ArgumentNullException.ThrowIfNullOrWhiteSpace(id);
      return genres.Single(genre => genre.Id == int.Parse(id));
  }
}
