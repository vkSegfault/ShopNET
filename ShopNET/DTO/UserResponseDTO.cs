using ShopNET.Models;

namespace ShopNET.DTO;

public class UserResponseDTO
{
    public Guid Id { get; internal set; }

    public string Name { get; internal set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public List<Item>? PurchasedItems { get; set; }

    public DateTime CreatedDateTime { get; internal set; }

    public DateTime LastModifiedDateTime { get; internal set; }

    public UserResponseDTO() { }

    public UserResponseDTO(Guid id, string name, string surname, List<Item> purchasedItems, DateTime createdDateTime, DateTime lastModifiedDateTime)
    {
        Id = id;
        Name = name;
        Surname = surname;
        PurchasedItems = purchasedItems;
        CreatedDateTime = createdDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
    }
}