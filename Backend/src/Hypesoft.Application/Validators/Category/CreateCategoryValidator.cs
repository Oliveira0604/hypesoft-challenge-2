using System.Data;
using FluentValidation;
using Hypesoft.Application.UseCase.Categories.Commands.CreateCategory;

namespace Hypesoft.Application.Validators.Category;
public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("O nome da categoria não pode ser vázio.")
            .MinimumLength(5).WithMessage("O nome não pode ter menos de 5 caracteres")
            .MaximumLength(20).WithMessage("O nome não pode ter mais de 20 caracteres");
    }
}