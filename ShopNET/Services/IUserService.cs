using ShopNET.Models;
using ShopNET.DTO;

namespace ShopNET.Services;


public interface IUserService
{
    void CreateUser(User user);
    Task<User> GetUserAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task UpdateUserAsync(User User);
    Task<bool> UserExistsAsync(Guid id);
    Task DeleteUserAsync(Guid id);
}