using ProjectManagement.API.Models;
using ProjectManagement.API.Models.DataTransferObjects;

namespace ProjectManagement.API.Services
{
    public interface IDepartmentService
    {
        Task<bool> CheckDepartment(int id);
        Task<int> CreateDepartment(CreateDepartmentRequest department);
        Task<DepartmentResponse> GetById(int id);
        Task<List<DepartmentResponse>> GetDepartments();
        Task<bool> Update(UpdateDepartmentRequest department);

        Task<bool> Delete(int id);
    }
}