using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace ShopNET.Models;

[Table("users")]
public class User : DbContext
{
    [Key]
    // [Column("userId")]
    // use Guid instead
    public Guid UserId { get; set; }

    // [Required]
    // [Column("name")]
    public string Name { get; set; } = string.Empty;

    // [Required]
    // [Column("surname")]
    public string Surname { get; set; } = string.Empty;

    // one-to-many relation - list of purchased items - just including different type will create Foreign Key
    // [Column("purchased")]
    // [ForeignKey("UserId_FK")]
    public virtual List<Item> PurchasedItems { get; set; }

    // In entity framework the table columns are represented by non-virtual properties, the relations between the tables are represented by virtual properties
    // [ForeignKey("ItemId")]
    // [NotMapped]
    // [InverseProperty(nameof(Item.User))]
    // [Column("favourite")]

    // ForeignKey
    // public Guid ItemId_FK { get; set; }
    // [ForeignKey("ItemId_FK")]
    // [Required]
    // [NotMapped]
    // public Item Item { get; set; }
    // [ForeignKey("Item")]
    // [Required]
    // public Guid ItemId { get; set; }

    // NavigationKey
    // [ValidateNever]
    // [NotMapped] // not only block mapping to DB but also disable Naviagtion Property

    // [Column("created")]
    public DateTime CreatedDateTime { get; set; }

    // [Column("modified")]
    public DateTime LastModifiedDateTime { get; set; }

    public User() { }

    public User(Guid id, string name, string surname, DateTime createdDateTime, DateTime lastModifiedDateTime)
    {
        UserId = id;
        Name = name;
        Surname = surname;
        // PurchasedItems = purchasedItems;
        CreatedDateTime = createdDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
    }

}