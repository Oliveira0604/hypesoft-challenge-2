using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.DTOs.Product;
using MediatR;
using FluentValidation;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateproductCategory;

public class UpdateProductCategoryHandler(IProductRepository repository, IValidator<UpdateProductCategoryCommand> validator) : IRequestHandler<UpdateProductCategoryCommand, UpdateProductCategoryResponse>
{
    public async Task<UpdateProductCategoryResponse> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var product = await repository.GetByIdAsync(request.Id) ?? throw new Exception("O produto não existe.");

        product.UpdateCategory(request.Category);

        await repository.UpdateCategoryAsync(product);

        return new UpdateProductCategoryResponse(
            product.Id,
            product.Category.Value
        );
    }
}