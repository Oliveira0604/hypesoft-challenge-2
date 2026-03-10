using MediatR;
using Hypesoft.Application.DTOs.Product.Response;
using Hypesoft.Domain.Interfaces;
using FluentValidation;

namespace Hypesoft.Application.UseCase.Products.Commands.DeleteProduct;
public class DeleteProductHandler(IProductRepository repository, IValidator<DeleteProductCommand> validator) : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var product = await repository.GetByIdAsync(request.Id) ?? throw new Exception("O produto não existe.");

        await repository.DeleteAsync(product);

        return new DeleteProductResponse(
            request.Id
        );
    }
}