using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Portfolio.Api.Options;

namespace Portfolio.Api.Context;

public class MongoContext
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _database;

    public MongoContext(IOptions<MongoOptions> options)
    {
        _mongoClient = new MongoClient(options.Value.ConnectionString);
        _database = _mongoClient.GetDatabase(options.Value.DatabaseName);
    }

    public IMongoDatabase Database => _database;

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}