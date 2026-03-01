using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Domain.ValueObjects;
using Hypesoft.Application.DTOs;
using Hypesoft.Application.Validators;
using FluentValidation;

namespace Hypesoft.Application.UseCase;

public class CreateProduct(IProductRepository repository, CreateProductValidator validator)
{
    public async Task<CreateProductResponse> Execute(CreateProductRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var existing = await repository.SearchByNameAsync(request.Name);

        if (existing.Any())
        {
            throw new Exception("Já existe um produto com esse nome.");
        }

        var product = new Product(
            new ProductName(request.Name),
            new Sku(request.Sku),
            new Price(request.Price),
            request.StockQuantity
        );

        await repository.AddAsync(product);

        return new CreateProductResponse(
            product.Id,
            product.Name.Value, 
            product.Price.Value
        );
    }
}