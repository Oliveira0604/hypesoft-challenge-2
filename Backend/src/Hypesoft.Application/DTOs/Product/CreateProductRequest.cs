namespace Hypesoft.Application.DTOs.Product;

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    string Sku,
    int StockQuantity
    
);