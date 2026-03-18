using FluentValidation;
using Hypesoft.Application.UseCase.Products.Queries.GetProductsByCategory;

namespace Hypesoft.Application.Validators.Product;

public class GetProductsByCategoryValidator : AbstractValidator<GetProductsByCategoryQuery>
{
    public GetProductsByCategoryValidator()
    {
        RuleFor(p => p.CategoryName)
            .NotEmpty().WithMessage("O nome da categoria não pode ser vázio");
    }
}