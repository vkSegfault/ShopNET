using ShopNET.Models;
using ShopNET.Contracts.Item;
using ShopNET.DTO;

namespace ShopNET.Services;


public interface IItemService
{
    void CreateItem(Item request);
    Task<Item> GetItemAsync(Guid id);
    Task<IEnumerable<Item>> GetAllItemsAsync();
    Task UpdateItemAsync(Item item);
    Task<bool> ItemExistsAsync(Guid id);
    Task DeleteItemAsync(Guid id);
}