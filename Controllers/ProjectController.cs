
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Teams.API.Data;
using Teams.API.Model;

namespace Teams.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        
        private IProjectRepository _projectRepo;

        private IConfiguration _configuration;

        public ProjectController(IProjectRepository projectRepository, IConfiguration configuration)
        {
            _projectRepo = projectRepository;
            _configuration = configuration;
        }

        [HttpGet("projects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var projectsList = _projectRepo.GetAllProjects();

            return Ok(projectsList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = _projectRepo.GetProjectById(id);

            return Ok(project);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(Projects project)
        {
            var result = await _projectRepo.UpdateProject(project);
            return Ok(result);
        }

        [HttpPost("addProject")]
        public async Task<IActionResult> AddProject(Projects project)
        {
            var result = await _projectRepo.AddProject(project);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (!await _projectRepo.DeleteProject(id))
                return StatusCode(404);

            return Ok();
        }
    }
}