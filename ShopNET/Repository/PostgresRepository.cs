using Microsoft.EntityFrameworkCore;
using Npgsql;
using ShopNET.Models;

namespace ShopNET.Repository;

public class ShopNETDBContext : DbContext
{
    public ShopNETDBContext() { }

    // this ctor is needed if injecting DB contnext from app chain
    public ShopNETDBContext(DbContextOptions<ShopNETDBContext> options) : base(options) { }


    // access Postgres tables
    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // server usually is not localhost, it's svc name (k8s) or docker ip adress of network
    //     optionsBuilder.UseNpgsql(connectionString: "Host=localhost;Username=user;Password=pass;Database=mydb");
    //     base.OnConfiguring(optionsBuilder);
    // }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Item>().ToTable("items");
    // }

    // public async void CreateItem(Item item)
    // {
    //     using var db = new ShopNETDBContext();
    //     await db.Items.AddAsync(item);
    //     await db.SaveChangesAsync();
    // }
}

// use for pure SQL access commands
// public class ShopNETSQL
// {
//     public static string connectionString = "Host=localhost;Username=user;Password=pass;Database=mydb";

//     public async void addItemSQL(Item item)
//     {
//         var conn = new NpgsqlConnection(connectionString: connectionString);
//         conn.Open();
//         using var cmd = new NpgsqlCommand();
//         cmd.Connection = conn;

//         cmd.CommandText = $"DROP TABLE IF EXISTS teachers";
//         await cmd.ExecuteNonQueryAsync();
//         cmd.CommandText = "CREATE TABLE teahcers (id SERIAL PRIMARY KEY," +
//             "first_name VARCHAR(255)," +
//             "last_name VARCHAR(255)," +
//             "subject VARCHAR(255)," +
//             "salary INT)";
//         await cmd.ExecuteNonQueryAsync();
//     }

// }