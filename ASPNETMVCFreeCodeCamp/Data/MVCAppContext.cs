using ASPNETMVCFreeCodeCamp.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCFreeCodeCamp.Data;

public class MVCAppContext : DbContext
{
    public MVCAppContext(DbContextOptions<MVCAppContext> options) : base(options)
    {
        
    }
    
    public DbSet<ItemModel>  Items { get; set; }
}