using FluentValidation;
using Hypesoft.Application.UseCase.Products.Queries.GetProductByName;

namespace Hypesoft.Application.Validators.Product;
public class GetProductByNameValidator : AbstractValidator<GetProductByNameQuery>
{
    public GetProductByNameValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("O nome do produto não pode ser vázio.");
    }
}