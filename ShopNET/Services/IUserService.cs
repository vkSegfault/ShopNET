using ShopNET.Models;
using ShopNET.DTO;

namespace ShopNET.Services;


public interface IItemService
{
    void CreateUser(User request);
    Task<User> GetUserAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task UpdateUserAsync(User User);
    Task<bool> UserExistsAsync(Guid id);
    Task DeleteUserAsync(Guid id);
}