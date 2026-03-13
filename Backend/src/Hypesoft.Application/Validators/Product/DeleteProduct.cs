using FluentValidation;
using Hypesoft.Application.UseCase.Products.Commands.DeleteProduct;

namespace Hypesoft.Application.Validators.Product;
public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty().WithMessage("O id não pode ser vázio.");
    }
}