namespace Hypesoft.Application.DTOs.Product.Response;

public record UpdateProductPriceResponse(
    string Id,
    string Name,
    decimal Price
);