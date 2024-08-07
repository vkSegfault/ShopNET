using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopNET.Models;

[Table("users")]
public class User : DbContext
{
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")]
    public Guid Id { get; internal set; }

    [Column("name")]
    public string Name { get; internal set; } = string.Empty;

    // one-to-many relation - list of purchased items
    [Column("purchased")]
    public List<Item>? PurchasedItems { get; internal set; }

}