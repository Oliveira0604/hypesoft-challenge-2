using Hypesoft.Domain.Entities;

namespace Hypesoft.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(string id);
    Task<IEnumerable<Product>> SearchByNameAsync(string name);
    //Task<IEnumerable<Product>> SearchByCategoryAsync(string categoryId);
    Task AddAsync(Product product);
    Task UpdateNameAsync(Product product);
    Task UpdatePriceAsync(Product product);
    Task UpdateDescriptionAsync(Product product);
    //Task DeleteAsync(string id);
}