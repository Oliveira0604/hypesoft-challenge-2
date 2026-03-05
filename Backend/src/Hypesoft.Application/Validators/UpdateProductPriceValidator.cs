using Hypesoft.Application.DTOs.Product;
using FluentValidation;

namespace Hypesoft.Application.Validators;

public class UpdateProductPriceValidator : AbstractValidator<UpdateProductPriceRequest>
{
    public UpdateProductPriceValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
    }
}