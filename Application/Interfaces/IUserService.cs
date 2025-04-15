using Domain.Entities;

namespace Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUser(int id);
    Task<int> CreateUser(User user);
}
