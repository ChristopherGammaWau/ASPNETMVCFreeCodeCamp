using ASPNETMVCFreeCodeCamp.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCFreeCodeCamp.Data;

public class MVCAppContext : DbContext
{
    public MVCAppContext(DbContextOptions<MVCAppContext> options) : base(options)
    {
        
    }

    // Seed test data if DB is empty
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemModel>().HasData(
            new ItemModel { Id = 1, Name = "Item 1", Price = 50.00, SerialNumberId = 1 }
        );
        modelBuilder.Entity<SerialNumberModel>().HasData(
            new SerialNumberModel{ Id = 1, Name = "SN001", ItemId = 1}
    );
}
    
    public DbSet<ItemModel>  Items { get; set; }
    public DbSet<SerialNumberModel> SerialNumbers { get; set; }
}