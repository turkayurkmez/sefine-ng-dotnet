using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Models;
using ProjectManagement.API.Models.DataTransferObjects;
using ProjectManagement.API.Services;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get()
        {
            //dependecy injection ile Program.cs üzerinde oluşturulan IDepartmentService interface'ini implemente eden nesneyi kullanıyoruz. 
            //DepartmentService departmentService = new DepartmentService();
            var departments = await _departmentsService.GetDepartments();
            return Ok(departments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            DepartmentResponse department = await _departmentsService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentRequest department)
        {
            //model doğrulama (department içinde belirtilen kurallara uyulmuş mu?):
            if (ModelState.IsValid)
            {
                int id = await _departmentsService.CreateDepartment(department);
                return CreatedAtAction(nameof(GetById), new { id = id }, department);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateDepartmentRequest department)
        {

            //1. id'li departman var mı?
            if (!await _departmentsService.CheckDepartment(id))
            {
                return NotFound(new { message = $"{id} id'li departman bulunamadı." });
            }
            //2. model doğrulama:
            if (ModelState.IsValid)
            {
                bool result = await _departmentsService.Update(department);
                if (result)
                {
                    return Ok(new { isSuccess = true, message = "Güncelleme başarılı." });
                }
            }
            //3. Yukarıdaki işlemlerden biri başarısız olursa:
            return BadRequest(ModelState);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            //1. id'li departman var mı?
            if (!await _departmentsService.CheckDepartment(id))
            {
                return NotFound(new { message = $"{id} id'li departman bulunamadı." });
            }
            //2. silme işlemi:
            bool result = await _departmentsService.Delete(id);
            if (result)
            {
                return Ok(new { isSuccess = true, message = "Silme işlemi başarılı." });
            }
            return BadRequest(new { isSuccess = false, message = "Silme işlemi başarısız. Bir hata oluştu..." });
        }


    }
}
