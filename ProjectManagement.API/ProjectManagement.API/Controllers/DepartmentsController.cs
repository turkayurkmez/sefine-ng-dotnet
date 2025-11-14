using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Models;
using ProjectManagement.API.Services;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private readonly IDepartmentService _departmentsService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentsService = departmentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //dependecy injection ile Program.cs üzerinde oluşturulan IDepartmentService interface'ini implemente eden nesneyi kullanıyoruz. 
            //DepartmentService departmentService = new DepartmentService();
            var departments = _departmentsService.GetDepartments();
            return Ok(departments);
        }
    }
}
