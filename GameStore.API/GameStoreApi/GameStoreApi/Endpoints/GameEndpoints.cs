using GameStoreApi.Dtos;

namespace GameStoreApi.Endponts;

public static class GameEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
        new
        (
            1,
            "FIFA 24",
            "Sport",
            10.10M,
            new DateOnly(2024, 1, 1)
        ),
        new
        (
            2,
            "Valorant",
            "Shooting",
            12.10M,
            new DateOnly(2020, 1, 1)
            ),
        new
        (
            3,
            "Bird",
            "Kid",
            1.10M,
            new DateOnly(2015, 1, 1)
        )
    ];

    public static RouteGroupBuilder MapGameEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();
        //Get
        group.MapGet("/", () => games);

        //Get By Id
        group.MapGet("/{id:int}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        //Create
        //Post /games
        group.MapPost("", (CreateGameDto newGame) =>
        {
            GameDto game = new
            (
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, 
                new { id = game.Id }, game);
            }
        );
        //.WithParameterValidation();

        //Update
        //Put /games
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        //Delete
        //Del /games/id
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
