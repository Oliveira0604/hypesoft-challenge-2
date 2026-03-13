using FluentValidation;
using Hypesoft.Application.UseCase.Products.Commands.UpdateProductStockQuantity;

namespace Hypesoft.Application.Validators.Product;

public class UpdateProductStockQuantityValidator : AbstractValidator<UpdateProductStockQuantityCommand>
{
    public UpdateProductStockQuantityValidator()
    {
        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque deve ser maior ou igual a zero.");
    }
}