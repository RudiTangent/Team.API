using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Teams.API.Data;
using Teams.API.Model;

namespace Teams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamRepository _teamRepo;

        private IConfiguration _configuration;

        public TeamController(ITeamRepository teamRepository, IConfiguration configuration)
        {
            _teamRepo = teamRepository;
            _configuration = configuration;
        }

        [HttpGet("Teams")]
        public async Task<IActionResult> GetAllTeams()
        {
            var TeamsList = await _teamRepo.GetAllTeam();

            return Ok(TeamsList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var Team = await _teamRepo.GetTeamById(id);

            return Ok(Team);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam(Team team)
        {
            var result = await _teamRepo.UpdateTeam(team);
            return Ok(result);
        }

        [HttpPost("addTeam")]
        public async Task<IActionResult> AddTeam(Team team)
        {
            var result = await _teamRepo.AddTeam(team);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (!await _teamRepo.DeleteTeam(id))
                return StatusCode(404);
            var newList = await _teamRepo.GetAllTeam();

            return Ok(newList);
        }
    }
}