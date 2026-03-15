using FluentValidation;
using Hypesoft.Application.UseCase.Categories.Commands.UpdateCategoryName;

namespace Hypesoft.Application.Validators.Category;

public class UpdateCategoryNameValidator : AbstractValidator<UpdateCategoryNameCommand>
{
    public UpdateCategoryNameValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("O id não pode ser vázio");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("O nome não pode ser vázio");
        
    }
}