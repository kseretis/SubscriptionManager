using Microsoft.AspNetCore.Mvc;
using SubscriptionManager.Database.Entities;

namespace SubscriptionManager.Endpoints.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting users.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"User with id {id} not found");
                return NotFound($"User with id {id} not found");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                int entriesAffected = await _userService.CreateUser(user);
                return Ok($"User created succesfully!\n{entriesAffected} lines effected!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"User couldn't be saved");
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
