using Microsoft.EntityFrameworkCore;
using ShopNET.Models;

namespace ShopNET.Repository;

public class ShopNETDBContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    // this ctor is needed if injecting DB contnext from app chain
    // public ShopNETDBContext(DbContextOptions<ShopNETDBContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // server usually is not localhost, it's svc name (k8s) or docker ip adress of network
        optionsBuilder.UseNpgsql(connectionString: "Host=localhost;Username=user;Password=pass;Database=mydb");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().ToTable("items");
    }

    public async void CreateItem(Item item)
    {
        using var db = new ShopNETDBContext();
        await db.Items.AddAsync(item);
        await db.SaveChangesAsync();
    }
}