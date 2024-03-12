using FelipeDiasAzevedo.StoneX.Business.ViewModels.Product;
using FluentValidation;

namespace FelipeDiasAzevedo.StoneX.Business.Validators;

public class ProductValidator : AbstractValidator<NewProductViewModel>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
        
        RuleFor(p => p.StockKeepingUnit)
            .NotNull()
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(12);
        
        RuleFor(p => p.Price)
            .NotNull()
            .GreaterThan(0.0m);
        
        RuleFor(p => p.StockCount)
            .NotNull()
            .GreaterThan(0);
    }
}