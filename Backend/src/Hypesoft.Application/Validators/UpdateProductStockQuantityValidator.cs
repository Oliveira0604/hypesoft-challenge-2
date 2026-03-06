using FluentValidation;
using Hypesoft.Application.DTOs.Product;

namespace Hypesoft.Application.Validators;

public class UpdateProductStockQuantityValidator : AbstractValidator<UpdateProductStockQuantityRequest>
{
    public UpdateProductStockQuantityValidator()
    {
        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque deve ser maior ou igual a zero.");
    }
}