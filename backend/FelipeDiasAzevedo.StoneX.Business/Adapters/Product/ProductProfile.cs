using AutoMapper;
using FelipeDiasAzevedo.StoneX.Business.ViewModels.Product;
using FelipeDiasAzevedo.StoneX.Infra.Models.Product;

namespace FelipeDiasAzevedo.StoneX.Business.Adapters.Product;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<NewProductViewModel, ProductModel>();
    }
}