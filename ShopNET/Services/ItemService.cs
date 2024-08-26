using ShopNET.Models;
using ShopNET.Contracts.Item;
using ShopNET.Repository;
using ShopNET.Interfaces;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ShopNET.Services;

public class ItemService : IItemService
{
    // private static readonly ShopNETSQL _sql = new ShopNETSQL();

    // DI
    private readonly ShopNETDBContext _context;
    public ItemService(ShopNETDBContext context)
    {
        _context = context;
    }

    public async Task CreateItem(Item item)
    {
        await _context.Items.AddAsync(item);   // track changes
        await _context.SaveChangesAsync();   // save changes to DB
        // _sql.addItemSQL(item);
    }

    public async Task<Item> GetItemAsync(Guid id)
    {
        var item = await _context.Items.FindAsync(id);

        if (item != null)
        {
            return item;
        }
        else
        {
            return null;
        }
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        // .ToList() makes it lazy-evaluated so that we will get 1 Item at time and not all of them at once
        // but .Select() makes it IEnumerable which is accepted in IAction returned functions in Controllers
        var items = await _context.Items.ToListAsync();

        return items;
    }

    public async Task UpdateItemAsync(Item item)
    {
        if (item != null)
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

    public async Task<bool> ItemExistsAsync(Guid id)
    {
        var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);   // this line starts tracking an object, don't create new one if already exists
        if (item != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task DeleteItemAsync(Guid id)
    {
        var item = await GetItemAsync(id);
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
    }
}