using Domain.Models;

namespace Application.Interfaces;

public interface IProgramService
{
    Task<int> CreateProgram(Program program);
    Task<Program?> GetProgram(int id);
    Task<IEnumerable<Program>> GetPrograms();
    Task<int> UpdateProgram(Program program);
    Task<int> DeleteProgram(int id);
}
