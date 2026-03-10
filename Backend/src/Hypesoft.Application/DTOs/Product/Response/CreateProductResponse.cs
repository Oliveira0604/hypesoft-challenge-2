namespace Hypesoft.Application.DTOs.Product.Response;

public record CreateProductResponse(
    string Id,
    string Name,
    decimal Price
);