using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;
using ProjectManagement.API.Repositories;
using System.Threading.Tasks;

namespace ProjectManagement.API.Services
{
    public class EFDepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository repository;

        public EFDepartmentService(IDepartmentRepository departmentRepository)
        {
            this.repository = departmentRepository;
        }

        public async Task<List<Department>> GetDepartments()
        {
            var departments = await repository.GetAllAsync();
            return departments;
        }
    }
}
