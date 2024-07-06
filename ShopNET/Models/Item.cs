namespace ShopNET.Models;

public class Item
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Tags { get; }


    public Item(Guid id, string name, string description, DateTime createdDateTime, DateTime lastModifiedDateTime, List<string> tags)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Tags = tags;
    }
}