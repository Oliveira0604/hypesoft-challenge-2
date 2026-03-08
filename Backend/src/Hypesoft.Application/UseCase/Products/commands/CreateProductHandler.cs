using Hypesoft.Application.DTOs.Product;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.ValueObjects.Product;
using Hypesoft.Application.Validators;
using FluentValidation;
using MediatR;

namespace Hypesoft.Application.UseCase.Products.Commands;

public class CreateProductHandler(IProductRepository repository, IValidator<CreateProductCommand> validator) : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var productExist = await repository.SearchByNameAsync(request.Name);

        if (productExist.Any())
        {
            throw new Exception("O produto já existe.");
        }

        var product = new Product(
            new Name(request.Name),
            new Price(request.Price),
            new Description(request.Description),
            new Category(request.Category),
            new StockQuantity(request.StockQuantity)
        );

        await repository.AddAsync(product);

        return new CreateProductResponse(
            product.Id,
            product.Name.Value,
            product.Price.Value
        );

    }
}