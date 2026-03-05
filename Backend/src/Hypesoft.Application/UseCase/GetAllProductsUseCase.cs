using Hypesoft.Application.DTOs.Product;
using Hypesoft.Domain.Interfaces;

namespace Hypesoft.Application.UseCase;

public class GetAllProductsUseCase(IProductRepository repository)
{
    public async Task<IEnumerable<GetAllProductsResponse>> Execute()
    {
        var products = await repository.GetAllAsync();

        return products.Select(p => new GetAllProductsResponse(
            p.Name.Value,
            p.Price.Value,
            p.Description.Value,
            p.StockQuantity.Value
        ));
    }
}