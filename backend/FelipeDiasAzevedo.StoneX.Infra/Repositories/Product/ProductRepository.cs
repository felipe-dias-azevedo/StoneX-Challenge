using FelipeDiasAzevedo.StoneX.Infra.Configuration.Mongo;
using FelipeDiasAzevedo.StoneX.Infra.Models.Product;
using FelipeDiasAzevedo.StoneX.Infra.Repositories.Generic;

namespace FelipeDiasAzevedo.StoneX.Infra.Repositories.Product;

public class ProductRepository : GenericRepository<ProductModel>, IProductRepository
{
    public ProductRepository(IMongoDbContext ctx) : base(ctx)
    {
        
    }
}