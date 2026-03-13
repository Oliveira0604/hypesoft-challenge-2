using FluentValidation;
using Hypesoft.Application.UseCase.Products.Commands.UpdateproductCategory;

namespace Hypesoft.Application.Validators.Product;

public class UpdateProductCategoryValidator : AbstractValidator<UpdateProductCategoryCommand>
{
    public UpdateProductCategoryValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("A categoria é obrigatória.")
            .MinimumLength(5).WithMessage("A categoria deve conter pelo menos 5 caracteres.")
            .MaximumLength(30).WithMessage("A categoria não pode exceder 30 caracteres.");
    }
}
