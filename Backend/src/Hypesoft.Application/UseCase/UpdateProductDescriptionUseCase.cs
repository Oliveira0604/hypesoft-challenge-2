using Hypesoft.Application.DTOs.Product;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.Validators;
using FluentValidation;

namespace Hypesoft.Application.UseCase;

public class UpdateProductDescriptionUseCase(IProductRepository repository, UpdateProductDescriptionValidator validator)
{
    public async Task<UpdateProductDescriptionResponse> Execute(string id, UpdateProductDescriptionRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var product = await repository.GetByIdAsync(id) ?? throw new Exception("Produto não encontrado.");

        product.UpdateDescription(request.Description);

        await repository.UpdateDescriptionAsync(product);
        return new UpdateProductDescriptionResponse(
            product.Id,
            product.Name.Value,
            product.Price.Value,
            product.Description.Value
        );
    }
}