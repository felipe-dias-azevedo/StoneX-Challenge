using AutoMapper;
using FelipeDiasAzevedo.StoneX.Business.Validators;
using FelipeDiasAzevedo.StoneX.Business.ViewModels.Product;
using FelipeDiasAzevedo.StoneX.Infra.Models.Product;
using FelipeDiasAzevedo.StoneX.Infra.Repositories.Product;
using FluentValidation;
using MongoDB.Bson;

namespace FelipeDiasAzevedo.StoneX.Business.Services.Product;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductModel>> Get()
    {
        var products = await _productRepository.Find();
        
        return products;
    }

    public async Task<ProductModel?> GetById(string id)
    {
        var product = await _productRepository.FindById(new ObjectId(id));
        
        return product;
    }

    public async Task Insert(NewProductViewModel viewModel)
    {
        Validate(viewModel);
        
        var model = _mapper.Map<ProductModel>(viewModel);
        
        await _productRepository.Insert(model);
    }

    public async Task Update(string id, NewProductViewModel viewModel)
    {
        Validate(viewModel);
        
        var model = _mapper.Map<ProductModel>(viewModel);

        model.Id = new ObjectId(id);
        model.UpdateDateTime = DateTime.UtcNow;
        
        await _productRepository.Update(model);
    }

    public async Task Delete(string id)
    {
        var product = await _productRepository.FindById(new ObjectId(id));

        if (product is null)
        {
            return;
        }
        
        await _productRepository.Delete(new ObjectId(id));
    }

    private void Validate(NewProductViewModel viewModel)
    {
        var validator = new ProductValidator();

        var validationResult = validator.Validate(viewModel);

        if (!validationResult.IsValid)
        {
            throw new ValidationException("Invalid Product", validationResult.Errors);
        }        
    }
}