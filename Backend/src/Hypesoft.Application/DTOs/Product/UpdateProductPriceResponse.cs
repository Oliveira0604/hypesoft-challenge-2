namespace Hypesoft.Application.DTOs.Product;

public record UpdateProductPriceResponse(
    string Id,
    string Name,
    decimal Price
);