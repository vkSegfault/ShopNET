using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopNET.Models;

[Table("items")]
public class Item : DbContext
{
    [System.ComponentModel.DataAnnotations.Key]
    // [Column("itemId")]
    public Guid ItemId { get; set; }

    // [Column("name")]
    public string Name { get; set; } = string.Empty;

    // [Column("description")]
    public string Description { get; set; } = string.Empty;

    // [Column("price")]
    public decimal Price { get; set; }

    // [Column("created")]
    public DateTime CreatedDateTime { get; set; }

    // [Column("modified")]
    public DateTime LastModifiedDateTime { get; set; }

    // [Column("tags")]
    public List<string>? Tags { get; set; }

    //Navigation key ? - allows access properies of User from here (?)
    // [NotMapped]
    // [ForeignKey(nameof(UserId))]
    // [InverseProperty("FavouriteItem")]
    // [Required]
    // public virtual User User { get; set; }

    // ForeignKey - auto mapped to User.UserId PrimaryKey (type must match!!) - is reflected in DB
    // [ForeignKey("UserId")]
    // [Required]
    // public Guid UserId { get; set; }

    // NavigationKey - allows access to User's properties - not reflected in DB
    // public int UserId_FK { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Item() { }

    public Item(Guid id, string name, string description, decimal price, DateTime createdDateTime, DateTime lastModifiedDateTime, List<string> tags)
    {
        ItemId = id;
        Name = name;
        Description = description;
        Price = price;
        CreatedDateTime = createdDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Tags = tags;
    }
}
