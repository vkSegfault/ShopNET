using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopNET.Models;

[Table("items")]
public class Item : DbContext
{
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")]
    public Guid Id { get; internal set; }

    [Column("name")]
    public string Name { get; internal set; } = string.Empty;

    [Column("description")]
    public string Description { get; internal set; } = string.Empty;

    [Column("price")]
    public decimal Price { get; internal set; }

    [Column("created")]
    public DateTime CreatedDateTime { get; internal set; }

    [Column("modified")]
    public DateTime LastModifiedDateTime { get; internal set; }

    [Column("tags")]
    public List<string> Tags { get; internal set; }

    //Navigation key ? - allows access properies of User from here (?)
    public User? User { get; set; };

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
