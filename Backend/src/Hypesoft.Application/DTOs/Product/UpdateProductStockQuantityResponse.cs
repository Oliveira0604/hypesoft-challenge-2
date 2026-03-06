namespace Hypesoft.Application.DTOs.Product;

public record UpdateProductStockQuantityResponse(
    string Id,
    string Name,
    int StockQuantity
);