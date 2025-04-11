using SubscriptionManager.Application.Interfaces;
using SubscriptionManager.Domain.Entities;
using SubscriptionManager.Infrastructure.Repositories;

namespace SubscriptionManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task<int> CreateUser(User user)
        {
            return await _userRepository.CreateUser(user);
        }
    }
}
