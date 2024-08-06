using ShopNET.DTO;
using ShopNET.Models;

namespace ShopNET.Mappers;

public static class ItemMapper
{
    public static ItemDTO ToItemDTO(this Item item)
    {
        return new ItemDTO
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Tags = item.Tags
        };
    }

}