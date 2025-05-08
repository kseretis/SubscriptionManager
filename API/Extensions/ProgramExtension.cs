using API.DTOs;
using Infrastructure.Extensions;

namespace API.Extensions;

public static class ProgramExtension
{
    public static Domain.Models.Program ToProgram(this ProgramDto programDto)
    {
        var program = new Domain.Models.Program
        {
            Name = programDto.Name,
            IsActive = programDto.IsActive,
            CreationDate = programDto.CreationDate.ToUniversalDateTimeOffset(),
        };

        if (programDto.Id.HasValue)
        {
            program.Id = programDto.Id.Value;
        }

        return program;
    }

    public static ProgramDto ToProgramDto(this Domain.Models.Program program)
    {
        return new ProgramDto
        {
            Id = program.Id,
            Name = program.Name,
            IsActive = program.IsActive,
            CreationDate = program.CreationDate.ToLocalTimezone(),
        };
    }
}
