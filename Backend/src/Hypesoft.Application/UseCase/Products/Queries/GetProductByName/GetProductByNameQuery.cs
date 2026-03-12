using MediatR;
using Hypesoft.Application.DTOs.Product.Response;

namespace Hypesoft.Application.UseCase.Products.Queries.GetProductByName;

public record GetProductByNameQuery(
    string Name
) : IRequest<List<GetProductByNameResponse>>;