using Hypesoft.Infrastructure.Mappings;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
namespace Hypesoft.Infrastructure.Context;

public class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(IConfiguration configuration)
    {
        ProductMapping.Configure();
        CategoryMapping.Configure();

        var connectionString = configuration.GetConnectionString("MongoDb");

        var databaseName = configuration["MongoSettings:DatabaseName"];

        if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
        {
            throw new ArgumentException("Configurações do MongoDB estão faltando ou são inválidas.");
        }

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name);
    
}