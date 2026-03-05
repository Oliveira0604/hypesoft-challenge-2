using FluentValidation;
using Hypesoft.Application.DTOs.Product;

namespace Hypesoft.Application.Validators;

public class UpdateProductNameValidator : AbstractValidator<UpdateProductNameRequest>
{
    public UpdateProductNameValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O novo nome é obrigatório.")
            .MinimumLength(3).WithMessage("O novo nome deve ter pelo menos 3 caracteres.")
            .MaximumLength(100).WithMessage("O novo nome não pode exceder 100 caracteres.");
    }
}