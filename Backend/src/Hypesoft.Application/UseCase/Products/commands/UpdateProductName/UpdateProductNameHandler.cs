using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.DTOs.Product;
using FluentValidation;
using MediatR;

namespace Hypesoft.Application.UseCase.Products.Commands.UpdateProductName;

public class UpdateProductNameHandler(IProductRepository repository, IValidator<UpdateProductNameCommand> validator) : IRequestHandler<UpdateProductNameCommand, UpdateProductNameResponse>
{
    public async Task<UpdateProductNameResponse> Handle(UpdateProductNameCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var product = await repository.GetByIdAsync(request.Id) ?? throw new Exception("O produto não existe");

        product.UpdateName(request.Name);

        await repository.UpdateNameAsync(product);

        return new UpdateProductNameResponse(
            product.Id,
            product.Name.Value
        );
        
    }
}