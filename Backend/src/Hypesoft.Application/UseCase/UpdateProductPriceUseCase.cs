using Hypesoft.Application.DTOs.Product;
using Hypesoft.Application.Validators;
using Hypesoft.Domain.Interfaces;
using FluentValidation;

namespace Hypesoft.Application.UseCase;

public class UpdateProductPriceUseCase(IProductRepository repository, UpdateProductPriceValidator validator)
{
    public async Task<UpdateProductPriceResponse> Execute(string id, UpdateProductPriceRequest request)
    {
        await validator.ValidateAndThrowAsync(request);
        var product = await repository.GetByIdAsync(id) ?? throw new Exception("Produto não encontrado.");

        product.UpdatePrice(request.Price);

        await repository.UpdatePriceAsync(product);

        return new UpdateProductPriceResponse(
            product.Id,
            product.Name.Value, 
            product.Price.Value);
    }
}