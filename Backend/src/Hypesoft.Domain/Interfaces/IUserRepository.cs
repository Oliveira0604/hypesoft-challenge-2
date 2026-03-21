using Hypesoft.Domain.Entities;

namespace Hypesoft.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(string id);
    Task<IEnumerable<User>> SearchByNameAsync(string name);
    Task AddUserAsync(User user);
    Task UpdateUserNameAsync(User user);
    Task UpdateUserEmailAsync(User user);
    Task UpdateUserCellphoneAsync(User user);
    Task UpdateUserPasswordAsync(User user);
    Task DeleteUserAsync(User user);
}