using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Interfaces;
using Hypesoft.Infrastructure.Context;
using MongoDB.Driver;
using MongoDB.Bson;
using Hypesoft.Domain.ValueObjects.User;
using ZstdSharp.Unsafe;

namespace Hypesoft.Infrastructure.Repositories;

public class UserRepository(MongoContext context) : IUserRepository
{
    private readonly IMongoCollection<User> _collection = context.GetCollection<User>("Usuarios");

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _collection.Find( _ => true).ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(string id)
    {
        return await _collection.Find(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<User>> SearchByNameAsync(string name)
    {
        var filter = Builders<User>.Filter.Regex(u => u.UserName, new BsonRegularExpression(name, "i"));
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task AddUserAsync(User user)
    {
        await _collection.InsertOneAsync(user);
    }

    public async Task UpdateUserNameAsync(User user)
    {
        await _collection.ReplaceOneAsync(u => u.Id == user.Id, user);
    }

    public async Task UpdateUserEmailAsync(User user)
    {
        await _collection.ReplaceOneAsync(u => u.Id == user.Id, user);
    }

    public async Task UpdateUserCellphoneAsync(User user)
    {
        await _collection.ReplaceOneAsync(u => u.Id == user.Id, user);
    }

    public async Task UpdateUserPasswordAsync(User user)
    {
        await _collection.ReplaceOneAsync(u => u.Id == user.Id, user);
    }

    public async Task DeleteUserAsync(User user)
    {
        await _collection.DeleteOneAsync(u => u.Id == user.Id);
    }
}