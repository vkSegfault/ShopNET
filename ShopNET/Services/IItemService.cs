using ShopNET.Models;
using ShopNET.Contracts.Item;
using ShopNET.DTO;

namespace ShopNET.Services;


public interface IItemService
{
    void CreateItem(Item request);
    Item GetItem(Guid id);
    IEnumerable<Item> GetAllItems();
    void UpdateItem(Guid id, Item item);
    bool ItemExists(Guid id);
    void DeleteItem(Guid id);
}