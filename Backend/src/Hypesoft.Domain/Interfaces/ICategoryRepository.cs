using Hypesoft.Domain.Entities;

namespace Hypesoft.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoryAsync();
    Task<Category?> GetCategoryByIdAsync(string id);
    Task<Category?> GetCategoryByNameAsync(string name);
    Task AddAsync(Category category);
    Task UpdateNameAsync(Category category);
    Task DeleteAsync(Category category);
}