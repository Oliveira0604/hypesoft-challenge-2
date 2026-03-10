using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.DTOs.Product.Response;
using FluentValidation;
using MediatR;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateProductPrice;

public class UpdateProductPriceHandler(IProductRepository repository, IValidator<UpdateProductPriceCommand> validator) : IRequestHandler<UpdateProductPriceCommand, UpdateProductPriceResponse>
{
    public async Task<UpdateProductPriceResponse> Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var product = await repository.GetByIdAsync(request.Id) ?? throw new Exception("O produto não existe.");

        product.UpdatePrice(request.Price);

        await repository.UpdatePriceAsync(product);

        return new UpdateProductPriceResponse(
            product.Id,
            product.Name.Value,
            product.Price.Value
        );
    }
}