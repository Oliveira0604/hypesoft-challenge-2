using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.DTOs.Product;
using MediatR;
using FluentValidation;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateProductStockQuantity;

public class UpdateProductStockQuantityHandler(IProductRepository repository, IValidator<UpdateProductStockQuantityCommand> validator) : IRequestHandler<UpdateProductStockQuantityCommand, UpdateProductStockQuantityResponse>
{
    public async Task<UpdateProductStockQuantityResponse> Handle(UpdateProductStockQuantityCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var product = await repository.GetByIdAsync(request.Id) ?? throw new Exception("O produto não existe");

        product.UpdateStockQuantity(request.StockQuantity);

        await repository.UpdateStockQuantityAsync(product);

        return new UpdateProductStockQuantityResponse(
            product.Id,
            product.StockQuantity.Value
        );
    }
}