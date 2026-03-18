using FluentValidation;
using MediatR;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.DTOs.Product.Response;
using Hypesoft.Application.DTOs.Product.Request;

namespace Hypesoft.Application.UseCase.Products.Queries.GetProductsByCategory;

public class GetProductsByCategoryHandler(IProductRepository repository, IValidator<GetProductsByCategoryQuery> validator) : IRequestHandler<GetProductsByCategoryQuery, List<GetProductsByCategoryResponse>>
{
    public async Task<List<GetProductsByCategoryResponse>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var products = await repository.SearchByCategoryAsync(request.CategoryName) ?? throw new Exception("Nenhum produto encontrado com essa categoria.");

        return products.Select(p =>
        new GetProductsByCategoryResponse(
            p.Id,
            p.Name.Value,
            p.Price.Value,
            p.Description.Value,
            p.StockQuantity.Value
        )).ToList();
    }
}