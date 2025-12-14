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
            new ItemModel { Id = 1, Name = "Item 1", Price = 50.00, SerialNumberId = 1,  CategoryId = 1 }
        );
        modelBuilder.Entity<SerialNumberModel>().HasData(
            new SerialNumberModel { Id = 1, Name = "SN001", ItemId = 1 }
        );
        modelBuilder.Entity<ItemModel>().HasData(
            new ItemModel { Id = 2, Name = "Item 2", Price = 50.00, SerialNumberId = 2, CategoryId = 1 }
        );
        modelBuilder.Entity<SerialNumberModel>().HasData(
            new SerialNumberModel { Id = 2, Name = "SN002", ItemId = 2 }
        );
        modelBuilder.Entity<CategoryModel>().HasData(
            new CategoryModel { Id = 1, Name = "TestItemsAlpha" }
        );
        modelBuilder.Entity<CategoryModel>().HasData(
            new CategoryModel { Id = 2, Name = "TestItemsBeta" }
        );
    }

    public DbSet<ItemModel> Items { get; set; }
    public DbSet<SerialNumberModel> SerialNumbers { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
}