using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Infrastructure.Context;
using MongoDB.Driver;
using MongoDB.Bson;
using Hypesoft.Domain.ValueObjects.Category;

namespace Hypesoft.Infrastructure.Repositories;

public class CategoryRepository(MongoContext context) : ICategoryRepository
{
    private readonly IMongoCollection<Category> _collection = context.GetCollection<Category>("Category");

     public async Task<IEnumerable<Category>> GetAllCategoryAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }
    
    public async Task<Category?> GetCategoryByIdAsync(string id)
    {
        return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        var nameToSearch = new Name(name);
        return await _collection.Find(c => c.Name == nameToSearch).FirstOrDefaultAsync();
    }

    public async Task AddAsync(Category category)
    {
        await _collection.InsertOneAsync(category);
    }

    public async Task UpdateNameAsync(Category category)
    {
        await _collection.ReplaceOneAsync(c => c.Id == category.Id, category);
    }

    public async Task DeleteAsync(Category category)
    {
        await _collection.DeleteOneAsync(c => c.Id == category.Id);
    }
}