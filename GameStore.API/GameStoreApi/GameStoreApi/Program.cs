using GameStoreApi.Dtos;
using GameStoreApi.Endponts;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGameEndpoint();

app.Run();
