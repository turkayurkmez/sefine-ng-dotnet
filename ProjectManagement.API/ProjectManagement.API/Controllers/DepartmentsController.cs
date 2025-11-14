using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var departments = new List<Department>
            {
                new Department { Id =1, Name ="Bilgi Teknolojileri"},
                new Department { Id =2, Name ="İnsan Kaynakları"},
                new Department { Id =3, Name ="Satın Alma"},
                new Department { Id =4, Name ="Pazarlama"}
            };

            return Ok(departments);
        }
    }
}
