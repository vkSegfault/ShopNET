using ShopNET.Models;
using ShopNET.Contracts.Item;
using ShopNET.DTO;

namespace ShopNET.Services;


public interface IItemService
{
    void CreateItem(Item request);
    Task<Item> GetItem(Guid id);
    Task<IEnumerable<Item>> GetAllItems();
    Task UpdateItem(Item item);
    Task<bool> ItemExists(Guid id);
    Task DeleteItem(Guid id);
}