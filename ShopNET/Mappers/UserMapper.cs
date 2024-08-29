using ShopNET.DTO;
using ShopNET.Models;

namespace ShopNET.Mappers;

public static class UserMapper
{
    public static UserResponseDTO ToUserResponseDTO(this User user)
    {
        return new UserResponseDTO
        {
            Id = user.UserId,
            Name = user.Name,
            Surname = user.Surname,
            // PurchasedItems = user.PurchasedItems,
            // Item = user.Item,
            CreatedDateTime = user.CreatedDateTime,
            LastModifiedDateTime = user.LastModifiedDateTime,
        };
    }

    public static User ToUser(this UserRequestDTO userRequestDTO)
    {
        return new User
        {
            // TODO - change Guid.NewGuid() to Guid.CreateVersion7() once .NET 9 is released
            UserId = Guid.NewGuid(),
            Name = userRequestDTO.Name,
            Surname = userRequestDTO.Surname,
            // PurchasedItems = null,
            CreatedDateTime = DateTime.UtcNow,
            LastModifiedDateTime = DateTime.UtcNow,
        };
    }

}