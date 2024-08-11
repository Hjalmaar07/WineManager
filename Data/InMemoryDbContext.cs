using Microsoft.EntityFrameworkCore;
using WineManager.Models.WineBottle;
using WineManager.Models.WineMaker;

namespace WineManager.Data;

public class InMemoryDbContext : DbContext
{
    public DbSet<WineMaker> WineMaker { get; set; }
    public DbSet<WineBottle> WineBottle { get; set; }

    public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WineMaker>().HasKey(x => x.Id);
        modelBuilder.Entity<WineBottle>().HasKey(x => x.Id);
    }
}
