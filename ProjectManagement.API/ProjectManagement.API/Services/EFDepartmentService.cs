using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;
using ProjectManagement.API.Models.DataTransferObjects;
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

        public async Task<bool> CheckDepartment(int id)
        {
            return await repository.IsExistsAsync(id);
        }

        public async Task<int> CreateDepartment(CreateDepartmentRequest request)
        {
            Department department = new Department
            {
                Name = request.Name
            };
            var createdDepartment = await repository.CreateAsync(department);
            return createdDepartment.Id;

        }

        public async Task<bool> Delete(int id)
        {
            return await repository.DeleteAsync(id);

        }

        public async Task<DepartmentResponse> GetById(int id)
        {
            var department = await repository.GetByIdAsync(id);
            if (department == null) return null;

            //mapping işlemi (Department -> DepartmentResponse): Yani department nesnesini DepartmentResponse nesnesine dönüştürme işlemi
            return new DepartmentResponse
            {
                Id = department.Id,
                Name = department.Name
            };
        }

        public async Task<List<DepartmentResponse>> GetDepartments()
        {
            var departments = await repository.GetAllAsync();
            var result = departments.Select(d => new DepartmentResponse
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();

            return result;
        }

        public async Task<bool> Update(UpdateDepartmentRequest departmentRequest)
        {
            var department = new Department
            {
                Id = departmentRequest.Id,
                Name = departmentRequest.Name
            };
            var departmentUpdated = await repository.UpdateAsync(department);
            return departmentUpdated != null;
        }
    }
}
