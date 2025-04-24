using Domain.Models;

namespace Application.Interfaces;

public interface IUserService
{
    Task<int> CreateUser(User user);
    Task<User?> GetUser(int id);
    Task<IEnumerable<User>> GetUsers();
    Task<int> UpdateUser(User user);
    Task<int> DeleteUser(int id);
}
