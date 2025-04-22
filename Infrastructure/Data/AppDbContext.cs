using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Individual> Individuals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("mainApp");

        modelBuilder.Entity<Individual>().OwnsOne(u => u.FirstName, name =>
        {
            name.Property(n => n.Value).HasColumnName("FirstName").IsRequired().HasMaxLength(100);
        })
            .OwnsOne(u => u.MiddleName, name =>
        {
            name.Property(n => n.Value).HasColumnName("MiddleName").HasMaxLength(100);
        })
            .OwnsOne(u => u.LastName, name =>
        {
            name.Property(n => n.Value).HasColumnName("LastName").IsRequired().HasMaxLength(100);
        });

        base.OnModelCreating(modelBuilder);
    }
}
