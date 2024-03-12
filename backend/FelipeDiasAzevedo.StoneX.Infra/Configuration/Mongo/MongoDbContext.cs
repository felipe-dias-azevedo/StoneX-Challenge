using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FelipeDiasAzevedo.StoneX.Infra.Configuration.Mongo;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _db;
    
    public MongoDbContext(IOptions<MongoSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _db = client.GetDatabase(settings.Value.Database);
    }
    
    public IMongoCollection<T> GetCollection<T>()
    {
        var collection = GetCollectionName(typeof(T));
        
        return _db.GetCollection<T>(collection);
    }
    
    private string? GetCollectionName(Type documentType)
    {
        var attribute = documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault() as BsonCollectionAttribute;
        
        return attribute?.CollectionName;
    }
}