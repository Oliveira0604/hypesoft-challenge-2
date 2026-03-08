using MediatR;
using Hypesoft.Application.DTOs.Product;

namespace Hypesoft.Application.UseCase.Products.Commands;

public record CreateProductCommand(
    string Name,
    decimal Price,
    string Description,
    string Category,
    int StockQuantity
) : IRequest<CreateProductResponse>;