using Hypesoft.Application.DTOs.Product;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.Validators;
using FluentValidation;

namespace Hypesoft.Application.UseCase;

public class UpdateProductCategoryUseCase(IProductRepository repository, UpdateProductCategoryValidator validator)
{
    public async Task<UpdateProductCategoryResponse> Execute(string id, UpdateProductCategoryRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var product = await repository.GetByIdAsync(id) ?? throw new Exception("Produto não encontrado.");

        product.UpdateCategory(request.Category);

        await repository.UpdateCategoryAsync(product);

        return new UpdateProductCategoryResponse(
            product.Id,
            product.Name.Value,
            product.Category.Value
        );
    }
}