using MongoDB.Driver;

namespace FelipeDiasAzevedo.StoneX.Infra.Configuration.Mongo;

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>();
}