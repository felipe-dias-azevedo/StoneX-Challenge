using System.Net;
using Asp.Versioning;
using FelipeDiasAzevedo.StoneX.Business.Services.Product;
using FelipeDiasAzevedo.StoneX.Business.ViewModels.Product;
using FelipeDiasAzevedo.StoneX.Controllers.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FelipeDiasAzevedo.StoneX.Controllers.V1;

[ApiVersion(1.0)]
[Route("v{version:apiVersion}/[controller]")]
public class ProductController : GenericController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productService.Get();

        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var products = await _productService.GetById(id);

        return Ok(products);
    }
    
    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] NewProductViewModel viewModel)
    {
        await _productService.Insert(viewModel);

        return StatusCode((int)HttpStatusCode.Created);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        [FromRoute] string id, 
        [FromBody] NewProductViewModel viewModel)
    {
        await _productService.Update(id, viewModel);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Update([FromRoute] string id)
    {
        await _productService.Delete(id);

        return Ok();
    }
}