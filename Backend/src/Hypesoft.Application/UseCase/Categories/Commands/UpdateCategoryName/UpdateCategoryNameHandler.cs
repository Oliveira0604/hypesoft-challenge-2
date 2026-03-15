using MediatR;
using FluentValidation;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.DTOs.Category.Response;

namespace Hypesoft.Application.UseCase.Categories.Commands.UpdateCategoryName;

public class UpdateCategoryNameHandler(ICategoryRepository repository, IValidator<UpdateCategoryNameCommand> validator) : IRequestHandler<UpdateCategoryNameCommand, UpdateCategoryNameResponse>
{
    public async Task<UpdateCategoryNameResponse> Handle(UpdateCategoryNameCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var category = await repository.GetCategoryByIdAsync(request.Id) ?? throw new Exception("A category não existe.");

        category.UpdateName(request.Name);

        await repository.UpdateNameAsync(category);

        return new UpdateCategoryNameResponse(
            category.Id
        );
    }
}