using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Database.Entities;

namespace SubscriptionManager.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
