using Hypesoft.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Hypesoft.Application.DTOs.Product.Response;

namespace Hypesoft.Application.UseCase.Products.Queries.GetProductByName;

public class GetProductByNameHandler(IProductRepository repository, IValidator<GetProductByNameQuery> validator) : IRequestHandler<GetProductByNameQuery, List<GetProductByNameResponse>>
{
    public async Task<List<GetProductByNameResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var product = await repository.SearchByNameAsync(request.Name) ?? throw new Exception("Nenhum produto encontrado com esse nome.");

        return product.Select(p =>
        new GetProductByNameResponse(
            p.Id,
            p.Name.Value,
            p.Price.Value,
            p.Description.Value,
            p.Category.Value,
            p.StockQuantity.Value
        )).ToList();
    }
}