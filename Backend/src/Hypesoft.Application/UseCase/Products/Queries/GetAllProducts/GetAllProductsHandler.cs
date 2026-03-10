using Hypesoft.Domain.Interfaces;
using MediatR;
using Hypesoft.Application.DTOs.Product.Response;
namespace Hypesoft.Application.UseCase.Products.Queries.GetAllProducts;

public class GetAllProductsHandler(IProductRepository repository) : IRequestHandler<GetAllProductsQuery, List<GetAllProductsResponse>>
{
    public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await repository.GetAllAsync();

        return products.Select(p => 
            new GetAllProductsResponse(
                p.Id,
                p.Name.Value,
                p.Price.Value,
                p.Description.Value,
                p.Category.Value,
                p.StockQuantity.Value
            )
        ).ToList();
    }
}