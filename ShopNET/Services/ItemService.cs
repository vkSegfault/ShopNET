using ShopNET.Models;
using ShopNET.Contracts.Item;

namespace ShopNET.Services;

public class ItemService : IItemService
{
    //TODO - implement Repository so that we can save entries in DB
    private static readonly Dictionary<Guid, Item> _items = new();

    public void CreasteItem(Item item)
    {
        _items.Add(item.Id, item);
    }

    public Item GetItem(Guid id)
    {
        return _items[id];
    }

    // public ItemResponse UpdateItem(Guid id, UpsertItemRequest request)
    // {
    //     pass;
    // }
    // public ItemResponse DeleteItem(Guid id)
    // {
    //     throw;
    // }
}