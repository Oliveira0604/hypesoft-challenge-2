using Hypesoft.Application.DTOs.Product;
using Hypesoft.Application.Validators;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Domain.ValueObjects.Product;
using FluentValidation;

namespace Hypesoft.Application.UseCase;

public class CreateProductUseCase(IProductRepository repository, CreateProductValidator validator)
{
    public async Task<CreateProductResponse> Execute(CreateProductRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var productExists = await repository.SearchByNameAsync(request.Name);

        if (productExists.Any())
        {
            throw new Exception("Já existe um produto com esse nome.");
        }

        var product = new Product(
            new Name(request.Name),
            new Price(request.Price),
            new Description(request.Description),
            new Sku(request.Sku),
            new StockQuantity(request.StockQuantity)
        );

        await repository.AddAsync(product);

        return new CreateProductResponse(
            product.Name.Value, 
            product.Price.Value
        );
    }
}