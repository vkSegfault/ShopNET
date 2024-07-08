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
    public string Name { get; internal set; }

    [Column("description")]
    public string Description { get; internal set; }

    [Column("created")]
    public DateTime CreatedDateTime { get; internal set; }

    [Column("modified")]
    public DateTime LastModifiedDateTime { get; internal set; }

    [Column("tags")]
    public List<string> Tags { get; internal set; }


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