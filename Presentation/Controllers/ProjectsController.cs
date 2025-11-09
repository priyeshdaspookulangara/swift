using Microsoft.AspNetCore.Mvc;
using ARCAERP.Domain.Entities;
using ARCAERP.Application.Interfaces;
using System.Threading.Tasks;

namespace ARCAERP.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        // GET: api/projects
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectsService.GetAllProjectsAsync();
            return Ok(projects);
        }

        // GET: api/projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _projectsService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        // POST: api/projects
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _projectsService.CreateProjectAsync(project);
            return CreatedAtAction(nameof(GetProject), new { id = project.ProjectId }, project);
        }

        // POST: api/projects/5/costs
        [HttpPost("{id}/costs")]
        public async Task<IActionResult> AddProjectCost(int id, [FromBody] ProjectCost cost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _projectsService.AddCostToProjectAsync(id, cost);
            return Ok();
        }
    }
}
