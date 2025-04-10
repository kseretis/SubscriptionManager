using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Database;
using SubscriptionManager.Database.Entities;

namespace SubscriptionManager.Endpoints.Users
{
    public class UserService : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<int> CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            return await _dbContext.SaveChangesAsync();
        }

    }
}
