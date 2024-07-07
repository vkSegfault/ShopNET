using ShopNET.Models;
using ShopNET.Contracts.Item;

namespace ShopNET.Services;


public interface IItemService
{
    void CreasteItem(Item request);
    Item GetItem(Guid id);
    // ItemResponse UpdateItem(Guid id, UpsertItemRequest request);
    // ItemResponse DeleteItem(Guid id);
}