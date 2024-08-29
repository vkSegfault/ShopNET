using Microsoft.EntityFrameworkCore;
using Npgsql;
using ShopNET.Models;

namespace ShopNET.Repository;

public class UsersDBContext : DbContext
{
    public UsersDBContext() { }

    // this ctor is needed if injecting DB contnext from app chain
    public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options) { }


    // access Postgres tables
    public DbSet<User> Users { get; set; }

}