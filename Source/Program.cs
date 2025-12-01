using MongoDB.Entities;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

var bld = WebApplication.CreateBuilder(new WebApplicationOptions
{
   Args = args,
   EnvironmentName = Environments.Development,
   ContentRootPath = AppContext.BaseDirectory // ensure config is loaded from project folder
});
bld.Services
   .AddAuthenticationJwtBearer(o => o.SigningKey = bld.Configuration["JwtSigningKey"])
   .AddAuthorization()
   .AddFastEndpoints()
   .SwaggerDocument();

var app = bld.Build();

// Make sure ASPNETCORE_ENVIRONMENT=Development
Console.WriteLine($"Environment: {bld.Environment.EnvironmentName}");

var hostname = app.Configuration["hostname"]!;
var dbName = app.Configuration["DbName"]!;
var username = app.Configuration["MongoUser"]!;
var password = app.Configuration["MongoPass"]!;
var port = Convert.ToInt32(app.Configuration["MongoPort"]!);



// string host = "localhost";    // your MongoDB host
// int port = 27017;             // default port
// string username = "admin";
// string password = "abc123";


MongoClientSettings? clientSettings = null;
clientSettings = new MongoClientSettings
{
   Server = new MongoServerAddress(hostname, port),
   Credential = MongoCredential.CreateCredential("admin", username, password),
   ConnectTimeout = TimeSpan.FromSeconds(10),
   ServerSelectionTimeout = TimeSpan.FromSeconds(10)
};

await DB.InitAsync(dbName, clientSettings!);
_001_seed_initial_admin_account.SuperAdminPassword = app.Configuration["SuperAdminPassword"]!;
await DB.MigrateAsync();




app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints(c => c.Serializer.Options.PropertyNamingPolicy = null)
   .UseSwaggerGen();

app.Run();

public partial class Program { }