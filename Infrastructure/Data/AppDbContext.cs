using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Helpers;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Program> Programs { get; set; }
    public DbSet<ActiveSubscription> ActiveSubscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("mainApp");

        ConfigureUser(modelBuilder);
        ConfigurePerson(modelBuilder);
        ConfigureActiveSubscription(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void ConfigureUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .OwnsOne(u => u.Email, mail =>
            {
                mail.Property(n => n.Value).HasColumnName("Email").IsRequired().HasMaxLength(MagicNumbers.EmailLength);

                mail.Ignore(i => i.Address)
                    .Ignore(i => i.Domain)
                    .Ignore(i => i.TopLevelDomain);
            })
            .OwnsOne(u => u.PhoneNumber, number =>
            {
                number.Property(n => n.Value).HasColumnName("PhoneNumber").HasMaxLength(MagicNumbers.PhoneNumberLength);

                number.Ignore(i => i.CountryCode)
                      .Ignore(i => i.Number);
            });
    }

    private static void ConfigurePerson(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .OwnsOne(p => p.FirstName, name =>
            {
                name.Property(n => n.Value).HasColumnName("FirstName").IsRequired().HasMaxLength(MagicNumbers.NameLength);
            })
            .OwnsOne(p => p.MiddleName, name =>
            {
                name.Property(n => n.Value).HasColumnName("MiddleName").HasMaxLength(MagicNumbers.NameLength);
            })
            .OwnsOne(p => p.LastName, name =>
            {
                name.Property(n => n.Value).HasColumnName("LastName").IsRequired().HasMaxLength(MagicNumbers.NameLength);
            });
    }

    private static void ConfigureActiveSubscription(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActiveSubscription>()
                    .Property(s => s.SubscriptionType)
                    .HasConversion<string>();
    }
}
