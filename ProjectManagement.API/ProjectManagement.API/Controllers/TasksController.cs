using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Models.DataTransferObjects;
using ProjectManagement.API.Services;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _taskService.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("by-project/{projectId:int}")]
        public async Task<IActionResult> GetByProject(int projectId)
        {
            var tasks = await _taskService.GetTasksByProject(projectId);
            return Ok(tasks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            TaskResponse task = await _taskService.GetById(id);
            if (task == null)
            {
                return NotFound(new { message = $"{id} id'li görev bulunamadý." });
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskRequest task)
        {
            if (ModelState.IsValid)
            {
                int id = await _taskService.CreateTask(task);
                return CreatedAtAction(nameof(GetById), new { id = id }, task);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateTaskRequest task)
        {
            //1. id'li görev var mý?
            if (!await _taskService.CheckTask(id))
            {
                return NotFound(new { message = $"{id} id'li görev bulunamadý." });
            }

            //2. model doðrulama:
            if (ModelState.IsValid)
            {
                bool result = await _taskService.Update(task);
                if (result)
                {
                    return Ok(new { isSuccess = true, message = "Güncelleme baþarýlý." });
                }
            }

            //3. Yukarýdaki iþlemlerden biri baþarýsýz olursa:
            return BadRequest(ModelState);
        }

        [HttpPatch("{id:int}/toggle-status")]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            //1. id'li görev var mý?
            if (!await _taskService.CheckTask(id))
            {
                return NotFound(new { message = $"{id} id'li görev bulunamadý." });
            }

            //2. durum deðiþtirme iþlemi:
            bool result = await _taskService.ToggleTaskStatus(id);
            if (result)
            {
                return Ok(new { isSuccess = true, message = "Görev durumu baþarýyla deðiþtirildi." });
            }
            return BadRequest(new { isSuccess = false, message = "Durum deðiþtirme iþlemi baþarýsýz." });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            //1. id'li görev var mý?
            if (!await _taskService.CheckTask(id))
            {
                return NotFound(new { message = $"{id} id'li görev bulunamadý." });
            }

            //2. silme iþlemi:
            bool result = await _taskService.Delete(id);
            if (result)
            {
                return Ok(new { isSuccess = true, message = "Silme iþlemi baþarýlý." });
            }
            return BadRequest(new { isSuccess = false, message = "Silme iþlemi baþarýsýz. Bir hata oluþtu..." });
        }
    }
}
