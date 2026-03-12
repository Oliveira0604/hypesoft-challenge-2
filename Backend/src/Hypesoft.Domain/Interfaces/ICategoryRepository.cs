using Hypesoft.Domain.Entities;

namespace Hypesoft.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoryAsync();
    Task<Category?> GetCategoryByNameAsync(string name);
    Task AddAsync(Category category);
    Task UpdateCategoryName(string name);
    Task DeleteAsync(string id);
}