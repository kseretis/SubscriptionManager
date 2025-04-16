using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().OwnsOne(u => u.Name, name =>
        {
            name.Property(n => n.Value).HasColumnName("Name").IsRequired().HasMaxLength(100);
        });

        base.OnModelCreating(modelBuilder);
    }
}
