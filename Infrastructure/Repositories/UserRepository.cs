using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext context)
    {
        _dbContext = context;
    }
    public async Task<int> CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUser(int id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<int> UpdateUser(User user)
    {
        _dbContext.Users.Update(user);
        return await _dbContext.SaveChangesAsync();
    }

    public async void DeleteUser(int id)
    {
        var user = _dbContext.Users.FindAsync(id);

        if (user.IsCompleted) 
        {
            _dbContext.Users.Remove(user.Result);
        }
    }
}
