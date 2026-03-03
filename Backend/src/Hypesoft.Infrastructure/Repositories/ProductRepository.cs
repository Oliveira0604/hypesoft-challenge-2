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
        var filter = Builders<Product>.Filter.Regex(p => p.Name.Value, new MongoDB.Bson.BsonRegularExpression(name, "i"));
        return await _collection.Find(filter).ToListAsync();
    }
}