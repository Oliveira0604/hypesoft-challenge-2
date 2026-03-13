using MediatR;
using FluentValidation;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.ValueObjects.Category;
using Hypesoft.Application.DTOs.Category.Response;

namespace Hypesoft.Application.UseCase.Categories.Commands.CreateCategory;

public class CreateCategoryHandler(ICategoryRepository repository, IValidator<CreateCategoryCommand> validator) : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
{
    public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var categoryExist = await repository.GetCategoryByNameAsync(request.Name);

        if (categoryExist != null)
        {
            throw new Exception("A categoria já existe.");
        }

        var category = new Category(
            new Name(request.Name)
        );

        await repository.AddAsync(category);

        return new CreateCategoryResponse(
            category.Id
        );
    }
}