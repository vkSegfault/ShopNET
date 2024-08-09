using ShopNET.Models;
using ShopNET.Repository;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ShopNET.Services;

public class UserService : IUserService
{

    // DI
    private readonly ShopNETDBContext _context;
    public UserService(ShopNETDBContext context)
    {
        _context = context;
    }

    public async void CreateUser(User user)
    {
        await _context.Users.AddAsync(user);   // track changes
        await _context.SaveChangesAsync();   // save changes to DB
    }

    public async Task<User> GetUserAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user != null)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    public async Task UpdateUserAsync(User user)
    {
        if (user != null)
        {
            // object already exists, just update it leaving old id
            await _context.SaveChangesAsync();
        }
        else
        {
            // object doesn't exist, no update should be made!
            throw new BadHttpRequestException("Updating object that doesn't exist");
        }
    }

    public async Task<bool> UserExistsAsync(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);   // this line starts tracking an object, don't create new one if already exists
        if (user != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await GetUserAsync(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}