using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;

    // This service should not return the User Entity but a DTO with the strict types

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

    public async Task<int> UpdateUser(User user)
    {
        return await _userRepository.UpdateUser(user);
    }

    public Task<int> DeleteUser(int id)
    {
        throw new NotImplementedException();
    }
}
