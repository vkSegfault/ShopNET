namespace ShopNET.Models;

public class Item
{
    public Guid Id;
    public string Name;
    public string Description;
    public DateTime CreatedDateTime;
    public List<string> Tags;


    public Item(Guid id, string name, string description, DateTime createdDateTime, List<string> tags)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        Tags = tags;
    }
}