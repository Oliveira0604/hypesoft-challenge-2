using MediatR;
using Hypesoft.Application.DTOs.Product.Response;

namespace Hypesoft.Application.UseCase.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    decimal Price,
    string Description,
    string Category,
    int StockQuantity
) : IRequest<CreateProductResponse>;