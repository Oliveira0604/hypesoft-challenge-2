using Hypesoft.Application.DTOs.Product.Response;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.ValueObjects.Product;
using FluentValidation;
using MediatR;

namespace Hypesoft.Application.UseCase.Products.Commands.CreateProduct;

public class CreateProductHandler(IProductRepository repository, ICategoryRepository categoryRepository, IValidator<CreateProductCommand> validator) : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var productExist = await repository.GetProductByName(request.Name);

        if (productExist != null)
        {
            throw new Exception("O produto já existe.");
        }

        var product = new Product(
            new Name(request.Name),
            new Price(request.Price),
            new Description(request.Description),
            new CategoryName(request.Category),
            new StockQuantity(request.StockQuantity)
        );
        _ = await categoryRepository.GetCategoryByNameAsync(request.Category) ?? throw new Exception("Essa categoria não existe.");

        await repository.AddAsync(product);

        return new CreateProductResponse(
            product.Id,
            product.Name.Value,
            product.Price.Value
        );

    }
}