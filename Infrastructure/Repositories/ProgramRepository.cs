using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProgramRepository
{
    public AppDbContext _dbContext;

    public ProgramRepository(AppDbContext context)
    {
        _dbContext = context;
    }
    public async Task<int> CreateProgram(Program program)
    {
        _dbContext.Programs.Add(program);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Program?> GetProgram(int id)
    {
        return await _dbContext.Programs.FindAsync(id);
    }

    public async Task<IEnumerable<Program>> GetPrograms()
    {
        return await _dbContext.Programs.ToListAsync();
    }

    public async Task<int> UpdateProgram(Program program)
    {
        _dbContext.Programs.Update(program);
        return await _dbContext.SaveChangesAsync();
    }

    public async void DeleteProgram(int id)
    {
        var program = _dbContext.Programs.FindAsync(id);
        if (program.IsCompleted)
        {
            _dbContext.Programs.Remove(program.Result);
        }

        await _dbContext.SaveChangesAsync();
    }
}
