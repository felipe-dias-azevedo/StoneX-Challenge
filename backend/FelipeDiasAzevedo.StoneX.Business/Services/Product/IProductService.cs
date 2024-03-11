using FelipeDiasAzevedo.StoneX.Business.ViewModels.Product;
using FelipeDiasAzevedo.StoneX.Infra.Models.Product;

namespace FelipeDiasAzevedo.StoneX.Business.Services.Product;

public interface IProductService
{
    Task<List<ProductModel>> Get();
    
    Task<ProductModel?> GetById(string id);
    
    Task Insert(NewProductViewModel model);
    
    Task Update(string id, NewProductViewModel model);
    
    Task Delete(string id);
    
}