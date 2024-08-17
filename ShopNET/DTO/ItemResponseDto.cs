namespace ShopNET.DTO;

public class ItemResponseDTO
{
    public Guid Id { get; internal set; }

    public string Name { get; internal set; } = string.Empty;

    public string Description { get; internal set; } = string.Empty;

    public decimal Price { get; internal set; }

    public List<string>? Tags { get; internal set; }

    public ItemResponseDTO() { }

    public ItemResponseDTO(Guid id, string name, string description, decimal price, List<string> tags)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Tags = tags;
    }
}