namespace ShopNET.DTO;

public class ItemDTO
{
    public Guid Id { get; internal set; }

    public string Name { get; internal set; } = string.Empty;

    public string Description { get; internal set; } = string.Empty;

    public decimal Price { get; internal set; }

    // public DateTime CreatedDateTime { get; internal set; }

    // public DateTime LastModifiedDateTime { get; internal set; }

    public List<string> Tags { get; internal set; }

    public ItemDTO() { }

    public ItemDTO(Guid id, string name, string description, decimal price, List<string> tags)  // DateTime createdDateTime, DateTime lastModifiedDateTime,
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Tags = tags;
    }
}

// CreatedDateTime = createdDateTime;
// LastModifiedDateTime = lastModifiedDateTime;