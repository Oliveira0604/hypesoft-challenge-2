namespace Hypesoft.Application.DTOs.Product;

public record UpdateProductDescriptionResponse(
    string Id,
    string Name,
    decimal Price,
    string Description
);