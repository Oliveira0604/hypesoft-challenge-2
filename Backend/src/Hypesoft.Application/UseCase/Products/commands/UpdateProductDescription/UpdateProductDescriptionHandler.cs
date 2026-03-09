using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.DTOs.Product;
using FluentValidation;
using MediatR;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateProductDescription;

public class UpdateProductDescriptionHandler(IProductRepository repository, IValidator<UpdateProductDescriptionCommand> validator) : IRequestHandler<UpdateProductDescriptionCommand, UpdateProductDescriptionResponse>
{
    public async Task<UpdateProductDescriptionResponse> Handle(UpdateProductDescriptionCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var product = await repository.GetByIdAsync(request.Id) ?? throw new Exception("O produto não existe.");

        product.UpdateDescription(request.Description);

        await repository.UpdateDescriptionAsync(product);

        return new UpdateProductDescriptionResponse(
            product.Id,
            product.Description.Value
        );
    }
}