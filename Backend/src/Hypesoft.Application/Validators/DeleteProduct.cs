using FluentValidation;
using Hypesoft.Application.UseCase.Products.Commands.DeleteProduct;

namespace Hypesoft.Application.Validators;
public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty().WithMessage("O id não pode ser vázio.");
    }
}