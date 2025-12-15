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
        
        // No mandatory according to: https://learn.microsoft.com/en-us/ef/core/modeling/relationships/
        // many-to-many#understanding-many-to-many-relationships
        // since EF Core automatically inferred the relationship.
        modelBuilder.Entity<ItemClientModel>().HasKey(ic => new { ic.ClientId, ic.ItemId });
        modelBuilder.Entity<ItemClientModel>().HasOne(ic => ic.Item).WithMany(ic => ic.ItemClientModels).HasForeignKey(ic => ic.ItemId);
        modelBuilder.Entity<ItemClientModel>().HasOne(ic => ic.Client).WithMany(ic => ic.ItemClientModels).HasForeignKey(ic => ic.ClientId);
        
        // NOTE: Not a recommended data seeding method for testing
        // FROM: https://learn.microsoft.com/en-us/ef/core/modeling
        // /data-seeding#configuration-options-useseeding-and-useasyncseeding-methods
        //---
        modelBuilder.Entity<CategoryModel>().HasData(
            new CategoryModel { Id = 1, Name = "TestItemsAlpha" }
        );
        modelBuilder.Entity<CategoryModel>().HasData(
            new CategoryModel { Id = 2, Name = "TestItemsBeta" }
        );
        //---
        modelBuilder.Entity<ClientModel>().HasData(
            new ClientModel { Id = 1, Name = "Drunk n Co" }
        );
        modelBuilder.Entity<ClientModel>().HasData(
            new ClientModel { Id = 2, Name = "Shovelware Games" }
        );
        //---
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
        modelBuilder.Entity<ItemModel>().HasData(
            new ItemModel { Id = 3, Name = "Item 3", Price = 150.00, SerialNumberId = 3, CategoryId = 2 }
        );
        modelBuilder.Entity<SerialNumberModel>().HasData(
            new SerialNumberModel { Id = 3, Name = "SN003", ItemId = 3 }
        );
        modelBuilder.Entity<ItemClientModel>().HasData(
            new ItemClientModel {ItemId = 1, ClientId = 1}
        );
        modelBuilder.Entity<ItemClientModel>().HasData(
            new ItemClientModel {ItemId = 2, ClientId = 2}
        );
        modelBuilder.Entity<ItemClientModel>().HasData(
            new ItemClientModel {ItemId = 3, ClientId = 2}
        );
    }

    public DbSet<ItemModel> Items { get; set; }
    public DbSet<SerialNumberModel> SerialNumbers { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ClientModel> Clients { get; set; }
    public DbSet<ItemClientModel> ItemClientModels { get; set; }
}