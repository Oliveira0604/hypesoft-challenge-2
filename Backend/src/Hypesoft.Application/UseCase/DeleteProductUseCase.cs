using Hypesoft.Domain.Interfaces;

namespace Hypesoft.Application.UseCase;

public class DeleteProductUseCase(IProductRepository repository)
{
    public async Task ExecuteAsync(string id)
    {
        var product = await repository.GetByIdAsync(id) ?? throw new Exception("Produto não encontrado");
        await repository.DeleteAsync(product);
    }
}