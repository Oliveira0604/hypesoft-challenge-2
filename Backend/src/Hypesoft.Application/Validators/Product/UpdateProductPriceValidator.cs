using FluentValidation;
using Hypesoft.Application.UseCase.Products.Commands.UpdateProductPrice;

namespace Hypesoft.Application.Validators.Product;

public class UpdateProductPriceValidator : AbstractValidator<UpdateProductPriceCommand>
{
    public UpdateProductPriceValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
    }
}