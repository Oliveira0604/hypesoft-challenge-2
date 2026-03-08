namespace Hypesoft.Application.DTOs.Product;

public record CreateProductResponse(
    string Id,
    string Name,
    decimal Price
);