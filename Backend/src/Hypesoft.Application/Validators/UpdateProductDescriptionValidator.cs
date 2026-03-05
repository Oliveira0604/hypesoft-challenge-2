using FluentValidation;
using Hypesoft.Application.DTOs.Product;

namespace Hypesoft.Application.Validators;

public class UpdateProductDescriptionValidator : AbstractValidator<UpdateProductDescriptionRequest>
{
    public UpdateProductDescriptionValidator()
    {
        RuleFor(x => x.Description)
        .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
        .MinimumLength(10).WithMessage("A descrição do produto deve conter pelo menos 10 caracteres.")
        .MaximumLength(1000).WithMessage("A descrição do produto deve conter no máximo 1000 caracteres.");

    }
}