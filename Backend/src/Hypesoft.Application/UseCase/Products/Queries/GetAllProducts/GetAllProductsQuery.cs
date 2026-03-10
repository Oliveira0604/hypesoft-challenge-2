using MediatR;
using Hypesoft.Application.DTOs.Product.Response;

namespace Hypesoft.Application.UseCase.Products.Queries.GetAllProducts;
public record GetAllProductsQuery() : IRequest<List<GetAllProductsResponse>>;