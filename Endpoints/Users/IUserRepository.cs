
using SubscriptionManager.Database.Entities;

namespace SubscriptionManager.Endpoints.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<int> CreateUser(User user);
    }
}
