using ShopNET.DTO;
using ShopNET.Models;

namespace ShopNET.Mappers;

public static class UserMapper
{
    public static UserResponseDTO TouUerResponseDTO(this User user)
    {
        return new UserResponseDTO
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            PurchasedItems = user.PurchasedItems,
            CreatedDateTime = user.CreatedDateTime,
            LastModifiedDateTime = user.LastModifiedDateTime,
        };
    }

    public static User ToUser(this UserRequestDTO userRequestDTO)
    {
        return new User
        {
            // TODO - change Guid.NewGuid() to Guid.CreateVersion7() once .NET 9 is released
            Id = Guid.NewGuid(),
            Name = userRequestDTO.Name,
            Surname = userRequestDTO.Surname,
            PurchasedItems = null,
            CreatedDateTime = DateTime.UtcNow,
            LastModifiedDateTime = DateTime.UtcNow,
        };
    }

}