using GameStoreApi.Data;
using GameStoreApi.Dtos;
using GameStoreApi.Endponts;

var builder = WebApplication.CreateBuilder(args);

var conString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(conString);

var app = builder.Build();

app.MapGameEndpoint();

app.Run();
