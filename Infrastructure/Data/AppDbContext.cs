using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("mainApp");

        modelBuilder.Entity<User>().OwnsOne(u => u.Name, name =>
        {
            name.Property(n => n.Value).HasColumnName("Name").IsRequired().HasMaxLength(100);
        });

        base.OnModelCreating(modelBuilder);
    }
}
