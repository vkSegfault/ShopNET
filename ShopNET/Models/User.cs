using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopNET.Models;

[Table("users")]
public class User : DbContext
{
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("surname")]
    public string Surname { get; set; } = string.Empty;

    // one-to-many relation - list of purchased items
    [Column("purchased")]
    public List<Item>? PurchasedItems { get; set; }

    [Column("created")]
    public DateTime CreatedDateTime { get; internal set; }

    [Column("modified")]
    public DateTime LastModifiedDateTime { get; internal set; }

    public User() { }

    public User(Guid id, string name, string surname, List<Item>? purchasedItems, DateTime createdDateTime, DateTime lastModifiedDateTime)
    {
        Id = id;
        Name = name;
        Surname = surname;
        PurchasedItems = purchasedItems;
        CreatedDateTime = createdDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
    }

}