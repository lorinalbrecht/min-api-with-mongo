using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var movieDatabaseConfigSection = builder.Configuration.GetSection("DatabaseSettings");
builder.Services.Configure<DatabaseSettings>(movieDatabaseConfigSection);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/check", (Microsoft.Extensions.Options.IOptions<DatabaseSettings> options) => {
    Console.WriteLine("ConnectionString:" + options.Value.ConnectionString  ?? "");
    string mongoConnection = options.Value.ConnectionString;
    var mongoClient = new MongoClient(mongoConnection);
    var databaseNames = mongoClient.ListDatabaseNames().ToList();

    return string.Join(",", databaseNames);
});

app.MapGet("/config", (Microsoft.Extensions.Options.IOptions<DatabaseSettings> options) => {
    return options.Value.TestX + "\n" + options.Value.TestY;
});

app.Run();
