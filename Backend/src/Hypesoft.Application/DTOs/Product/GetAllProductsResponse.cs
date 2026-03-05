namespace Hypesoft.Application.DTOs.Product;

public record GetAllProductsResponse(
    string Name,
    decimal Price,
    string Description,
    int StockQuantity
);