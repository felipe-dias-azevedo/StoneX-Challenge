using System.Linq.Expressions;
using FelipeDiasAzevedo.StoneX.Infra.Models.Generic;
using MongoDB.Bson;

namespace FelipeDiasAzevedo.StoneX.Infra.Repositories.Generic;

public interface IGenericRepository <T> where T : GenericModel
{
    Task<List<T>> Find();
    
    Task<List<T>> Find(Expression<Func<T, bool>> where);
    
    Task<T?> FindById(ObjectId id);
    
    Task Insert(T model);
    
    Task Update(T model);
    
    Task Delete(ObjectId id);
}