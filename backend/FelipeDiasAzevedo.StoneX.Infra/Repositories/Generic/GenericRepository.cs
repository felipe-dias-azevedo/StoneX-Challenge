using System.Linq.Expressions;
using FelipeDiasAzevedo.StoneX.Infra.Models.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FelipeDiasAzevedo.StoneX.Infra.Repositories.Generic;

public abstract class GenericRepository <T> : IGenericRepository <T> where T : GenericModel
{
    protected readonly IMongoCollection<T> _collection;

    protected GenericRepository()
    {
        
    }
    
    public async Task<List<T>> Find()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<List<T>> Find(Expression<Func<T, bool>> where)
    {
        return await _collection.Find(where).ToListAsync();
    }

    public async Task<T?> FindById(ObjectId id)
    {
        return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task Insert(T model)
    {
        await _collection.InsertOneAsync(model);
    }

    public async Task Update(T model)
    {
        await _collection.FindOneAndReplaceAsync(c => c.Id == model.Id, model);
    }

    public async Task Delete(ObjectId id)
    {
        await _collection.FindOneAndDeleteAsync(c => c.Id == id);
    }
}