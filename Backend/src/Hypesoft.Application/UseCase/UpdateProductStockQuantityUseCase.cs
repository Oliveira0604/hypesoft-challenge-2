using Hypesoft.Application.DTOs.Product;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.Validators;
using FluentValidation;

namespace Hypesoft.Application.UseCase;

public class UpdateProductStockQuantityUseCase(IProductRepository repository, UpdateProductStockQuantityValidator validator)
{
    public async Task<UpdateProductStockQuantityResponse> Execute(string id, UpdateProductStockQuantityRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var product = await repository.GetByIdAsync(id) ?? throw new Exception("Produto não encontrado");

        product.UpdateStockQuantity(request.StockQuantity);
        await repository.UpdateStockQuantityAsync(product);

        return new UpdateProductStockQuantityResponse(
            product.Id,
            product.Name.Value,
            product.StockQuantity.Value
        );
    }
}