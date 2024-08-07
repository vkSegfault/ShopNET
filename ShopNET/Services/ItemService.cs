using ShopNET.Models;
using ShopNET.Contracts.Item;
using ShopNET.Repository;
using System.Data.Common;

namespace ShopNET.Services;

public class ItemService : IItemService
{
    //TODO - implement Repository so that we can save entries in DB
    private static readonly Dictionary<Guid, Item> _items = new();
    // private static readonly ShopNETSQL _sql = new ShopNETSQL();

    // DI
    private readonly ShopNETDBContext _context;
    public ItemService(ShopNETDBContext context)
    {
        _context = context;
    }

    public void CreateItem(Item item)
    {
        // _items.Add(item.Id, item);
        // await _context.Items.AddAsync(item);
        // await _context.SaveChangesAsync();
        _context.Items.Add(item);   // track changes
        _context.SaveChanges();   // save changes to DB
        // _sql.addItemSQL(item);
    }

    public Item GetItem(Guid id)
    {
        var item = _context.Items.Find(id);

        if (item != null)
        {
            return item;
        }
        else
        {
            return null;
        }
    }

    public IEnumerable<Item> GetAllItems()
    {
        // .ToList() makes it lazy-evaluated so that we will get 1 Item at time and not all of them at once
        // but .Select() makes it IEnumerable which is accepted in IAction returned functions in Controllers
        var items = _context.Items.ToList();

        return items;
    }

    public void UpdateItem(Guid id, Item item)
    {
        if (_items.ContainsKey(id))
        {
            // object already exists, just update it leaving old id
            _items[id] = new Item(id, item.Name, item.Description, item.Price, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);
        }
        else
        {
            // object doesn't exist, no update should be made!
            throw new BadHttpRequestException("Updating object that doesn't exist");
        }
    }

    public bool ItemExists(Guid id)
    {
        if (_items.ContainsKey(id))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DeleteItem(Guid id)
    {
        if (_items.ContainsKey(id))
        {
            _items.Remove(id);
        }
    }
}