using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Teams.API.Data;
using Teams.API.Model;

namespace Teams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepo;

        private IConfiguration _configuration;

        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepo = userRepository;
            _configuration = configuration;
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var UsersList = _userRepo.GetAllUsers();

            return Ok(UsersList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var User = _userRepo.GetUsersById(id);

            return Ok(User);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(Users user)
        {
            var result = await _userRepo.UpdateUsers(user);
            return Ok(result);
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(Users user)
        {
            var result = await _userRepo.AddUsers(user);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!await _userRepo.DeleteUsers(id))
                return StatusCode(404);

            return Ok();
        }
    }
}