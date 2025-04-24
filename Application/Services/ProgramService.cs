using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class ProgramService : IProgramService
{
    private readonly ProgramRepository _programRepository;

    public ProgramService(ProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }

    public async Task<int> CreateProgram(Program program)
    {
        return await _programRepository.CreateProgram(program);
    }

    public async Task<Program?> GetProgram(int id)
    {
        return await _programRepository.GetProgram(id);
    }

    public async Task<IEnumerable<Program>> GetPrograms()
    {
        return await _programRepository.GetPrograms();
    }

    public Task<int> UpdateProgram(Program program)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteProgram(int id)
    {
        throw new NotImplementedException();
    }
}
