namespace Hypesoft.Application.DTOs.Product.Response;

public record GetProductByNameResponse(
    string Id,
    string Name,
    decimal Price,
    string Description,
    string Category,
    int StockQuantity
);