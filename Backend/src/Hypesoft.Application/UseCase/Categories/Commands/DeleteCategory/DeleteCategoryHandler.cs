using MediatR;
using FluentValidation;
using Hypesoft.Application.DTOs.Category.Response;
using Hypesoft.Domain.Interfaces;

namespace Hypesoft.Application.UseCase.Categories.Commands.DeleteCategory;

public class DeleteCategoryHandler(ICategoryRepository repository, IValidator<DeleteCategoryCommand> validator) : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
{
    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var category = await repository.GetCategoryByIdAsync(request.Id) ?? throw new Exception("A categoria não existe");

        await repository.DeleteAsync(category);

        return new DeleteCategoryResponse(
            request.Id
        );
    }
}
