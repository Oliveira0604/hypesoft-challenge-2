using FluentValidation;
using Hypesoft.Application.UseCase.Categories.Commands.DeleteCategory;

namespace Hypesoft.Application.Validators.Category;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("O id não pode ser vázio.");
    }
}