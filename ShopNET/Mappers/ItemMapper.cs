using ShopNET.DTO;
using ShopNET.Models;

namespace ShopNET.Mappers;

public static class ItemMapper
{
    public static ItemResponseDTO ToItemResponseDTO(this Item item)
    {
        return new ItemResponseDTO
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Tags = item.Tags
        };
    }

    public static Item ToItem(this ItemRequestDTO itemRequestDTO)
    {
        return new Item
        {
            // TODO - change Guid.NewGuid() to Guid.CreateVersion7() once .NET 9 is released
            Id = Guid.NewGuid(),
            Name = itemRequestDTO.Name,
            Description = itemRequestDTO.Description,
            Price = itemRequestDTO.Price,
            CreatedDateTime = DateTime.UtcNow,
            LastModifiedDateTime = DateTime.UtcNow,
            Tags = itemRequestDTO.Tags
        };
    }

}