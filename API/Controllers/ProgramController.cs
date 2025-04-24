using API.DTOs;
using API.Mappers;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgramController : ControllerBase
{
    private readonly IProgramService _programService;
    private readonly ILogger<ProgramController> _logger;

    public ProgramController(ILogger<ProgramController> logger, IProgramService programService)
    {
        _logger = logger;
        _programService = programService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProgram([FromBody] ProgramDto programDto)
    {
        try
        {
            var entriesAffected = await _programService.CreateProgram(programDto.ToProgram());
            return Ok($"Program created succesfully!\n{entriesAffected} lines effected!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Program couldn't be saved");
            return StatusCode(500, $"Something went wrong\n{ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetProgram(int id)
    {
        try
        {
            var program = await _programService.GetProgram(id);

            if (program is null)
            {
                return NotFound($"Program with id {id} not found");
            }

            return Ok(program.ToProgramDto());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong");
            return StatusCode(500, $"Something went wrong\n{ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetPrograms()
    {
        try
        {
            var programs = await _programService.GetPrograms();
            return Ok(programs.Select(p => p.ToProgramDto()).ToList());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting users.");
            return StatusCode(500, "Internal server error");
        }
    }
}
