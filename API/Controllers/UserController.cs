using API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using API.DTOs;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    //TODO
    // set up proto files and GRPC

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] UserDto userDto)
    {
        try
        {
            int entriesAffected = await _userService.CreateUser(userDto.ToUser());
            return Ok($"User created succesfully!\n{entriesAffected} lines effected!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"User couldn't be saved");
            return StatusCode(500, $"Something went wrong\n{ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        try
        {
            var user = await _userService.GetUser(id);

            if (user is null)
            {
                return NotFound($"User with id {id} not found");
            }

            return Ok(user.ToUserDto());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong");
            return StatusCode(500, $"Something went wrong\n{ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        try
        {
            var users = await _userService.GetUsers();
            return Ok(users.Select(u => u.ToUserDto()).ToList());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting users.");
            return StatusCode(500, "Internal server error");
        }
    }
}
