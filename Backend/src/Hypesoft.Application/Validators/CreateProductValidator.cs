using FluentValidation;
using MyProject.Application.DTOs;

namespace Hypesoft.Application.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres.")
            .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MinimumLength(10).WithMessage("Descrição deve ter pelo menos 10 caracteres.")
            .MaximumLength(500).WithMessage("Descrição não pode exceder 500 caracteres.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Preço deve ser maior que zero.");
    }
}