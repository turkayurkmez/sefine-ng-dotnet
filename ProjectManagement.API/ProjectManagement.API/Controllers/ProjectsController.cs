using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Models.DataTransferObjects;
using ProjectManagement.API.Services;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _projectService.GetProjects();
            return Ok(projects);
        }

        [HttpGet("with-tasks")]
        public async Task<IActionResult> GetWithTasks()
        {
            var projects = await _projectService.GetProjectsWithTasks();
            return Ok(projects);
        }

        [HttpGet("by-department/{departmentId:int}")]
        public async Task<IActionResult> GetByDepartment(int departmentId)
        {
            var projects = await _projectService.GetProjectsByDepartment(departmentId);
            return Ok(projects);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            ProjectResponse project = await _projectService.GetById(id);
            if (project == null)
            {
                return NotFound(new { message = $"{id} id'li proje bulunamadý." });
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectRequest project)
        {
            if (ModelState.IsValid)
            {
                int id = await _projectService.CreateProject(project);
                return CreatedAtAction(nameof(GetById), new { id = id }, project);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateProjectRequest project)
        {
            //1. id'li proje var mý?
            if (!await _projectService.CheckProject(id))
            {
                return NotFound(new { message = $"{id} id'li proje bulunamadý." });
            }

            //2. model doðrulama:
            if (ModelState.IsValid)
            {
                bool result = await _projectService.Update(project);
                if (result)
                {
                    return Ok(new { isSuccess = true, message = "Güncelleme baþarýlý." });
                }
            }

            //3. Yukarýdaki iþlemlerden biri baþarýsýz olursa:
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            //1. id'li proje var mý?
            if (!await _projectService.CheckProject(id))
            {
                return NotFound(new { message = $"{id} id'li proje bulunamadý." });
            }

            //2. silme iþlemi:
            bool result = await _projectService.Delete(id);
            if (result)
            {
                return Ok(new { isSuccess = true, message = "Silme iþlemi baþarýlý." });
            }
            return BadRequest(new { isSuccess = false, message = "Silme iþlemi baþarýsýz. Bir hata oluþtu..." });
        }
    }
}
