using Hypesoft.Domain.Interfaces;
using Hypesoft.Application.DTOs.Product;
using Hypesoft.Application.Validators;
using FluentValidation;

namespace Hypesoft.Application.UseCase;

public class UpdateProductNameUseCase(IProductRepository repository, UpdateProductNameValidator validator)
{
    public async Task<UpdateProductNameResponse> Execute(string id, UpdateProductNameRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var product = await repository.GetByIdAsync(id) ?? throw new Exception("Produto não encontrado.");

        product.UpdateName(request.Name);

        await repository.UpdateNameAsync(product);

        return new UpdateProductNameResponse(
            product.Name.Value
        );
    }
}