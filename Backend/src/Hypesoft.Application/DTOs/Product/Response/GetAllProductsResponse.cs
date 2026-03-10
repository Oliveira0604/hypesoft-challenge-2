namespace Hypesoft.Application.DTOs.Product.Response;

public record GetAllProductsResponse(
    string Name,
    decimal Price,
    string Description,
    int StockQuantity
);