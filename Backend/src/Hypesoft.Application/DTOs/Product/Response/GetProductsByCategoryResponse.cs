namespace Hypesoft.Application.DTOs.Product.Response;

public record GetProductsByCategoryResponse(
    string Id,
    string Name,
    decimal Price,
    string Description,
    int StockQuantity
);