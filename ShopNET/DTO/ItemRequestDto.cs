namespace ShopNET.DTO;

public class ItemRequestDTO
{
    // using `internal set` will block setters executed from Swagger UI and block show example body in Swagger UI because Swashbuckle package is external
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public List<string> Tags { get; set; }

    public ItemRequestDTO() { }

    public ItemRequestDTO(string name, string description, decimal price, List<string> tags)
    {
        Name = name;
        Description = description;
        Price = price;
        Tags = tags;
    }
}