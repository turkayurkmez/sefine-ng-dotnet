using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ProjectManagementDbContext _context;

        public DepartmentRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }
        public Task<Department> CreateAsync(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public Task<Department?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Department?> UpdateAsync(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
