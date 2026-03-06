using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Infrastructure.Context;
using MongoDB.Driver;

namespace Hypesoft.Infrastructure.Repositories;

public class ProductRepository(MongoContext context) : IProductRepository
{
    private readonly IMongoCollection<Product> _collection = context.GetCollection<Product>("Products");

    public async Task AddAsync(Product product)
    {
        await _collection.InsertOneAsync(product);
    }

    public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
    {
        var filter = Builders<Product>.Filter.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(name, "i"));
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(string id)
    {
        return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task UpdateNameAsync(Product product)
    {
        await _collection.ReplaceOneAsync(p => p.Id == product.Id, product);
    }

    public async Task UpdatePriceAsync(Product product)
    {
        await _collection.ReplaceOneAsync(p => p.Id == product.Id, product);
    }

    public async Task UpdateDescriptionAsync(Product product)
    {
        await _collection.ReplaceOneAsync(p => p.Id == product.Id, product);
    }

    public async Task UpdateCategoryAsync(Product product)
    {
        await _collection.ReplaceOneAsync(p => p.Id == product.Id, product);
    }
}