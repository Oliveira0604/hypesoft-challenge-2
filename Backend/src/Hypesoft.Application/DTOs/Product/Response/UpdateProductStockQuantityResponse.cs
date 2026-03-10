namespace Hypesoft.Application.DTOs.Product.Response;

public record UpdateProductStockQuantityResponse(
    string Id,
    int StockQuantity
);