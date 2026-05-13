using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Minimal API Version 1.0");

app.MapGet("/check", () =>
{
    try
    {
        var connectionString =
            "mongodb://gbs:geheim@localhost:27017";

        var client = new MongoClient(connectionString);

        var databases =
            client.ListDatabaseNames().ToList();

        return $"Zugriff auf MongoDB ok.\n\nDatenbanken:\n{string.Join("\n", databases)}";
    }
    catch (Exception ex)
    {
        return $"Fehler: {ex.Message}";
    }
});

app.Run();