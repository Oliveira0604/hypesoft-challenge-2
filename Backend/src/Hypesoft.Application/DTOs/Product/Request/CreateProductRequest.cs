namespace Hypesoft.Application.DTOs.Product.Request;

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    string Category,
    int StockQuantity
    
);