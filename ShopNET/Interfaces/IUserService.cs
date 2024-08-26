using ShopNET.Models;
using ShopNET.DTO;

namespace ShopNET.Interfaces;


public interface IUserService
{
    Task CreateUser(User user);
    Task<User> GetUserAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task UpdateUserAsync(User User);
    Task<bool> UserExistsAsync(Guid id);
    Task DeleteUserAsync(Guid id);
}