namespace Hypesoft.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(string id);
    Task<IEnumerable<Product>> SearchByNameAsync(string name);
    Task<IEnumerable<Product>> SearchByCategoryAsync(string categoryId);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(string id);
}