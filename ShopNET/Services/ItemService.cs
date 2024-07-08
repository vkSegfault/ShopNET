using ShopNET.Models;
using ShopNET.Contracts.Item;
using ShopNET.Repository;
using System.Data.Common;

namespace ShopNET.Services;

public class ItemService : IItemService
{
    //TODO - implement Repository so that we can save entries in DB
    private static readonly Dictionary<Guid, Item> _items = new();
    private static readonly ShopNETDBContext _db = new ShopNETDBContext();

    public void CreateItem(Item item)
    {
        _items.Add(item.Id, item);
        _db.CreateItem(item);
    }

    public Item GetItem(Guid id)
    {
        return _items[id];
    }

    public List<Item> GetAllItems()
    {
        return _items.Values.ToList<Item>();
    }

    public void UpdateItem(Guid id, Item item)
    {
        if (_items.ContainsKey(id))
        {
            // object already exists, just update it leaving old id
            _items[id] = new Item(id, item.Name, item.Description, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);
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