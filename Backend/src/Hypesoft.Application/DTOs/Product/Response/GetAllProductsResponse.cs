namespace Hypesoft.Application.DTOs.Product.Response;

public record GetAllProductsResponse(
    string Id,
    string Name,
    decimal Price,
    string Description,
    string Category,
    int StockQuantity
);