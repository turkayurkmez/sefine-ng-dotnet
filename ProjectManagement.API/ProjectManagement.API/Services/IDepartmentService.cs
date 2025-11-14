using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
    }
}