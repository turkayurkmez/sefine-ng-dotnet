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
        public async Task<Department> CreateAsync(Department entity)
        {
            await _context.Departments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
           return await _context.Departments.AnyAsync(d => d.Id == id);
        }

        public async Task<Department?> UpdateAsync(Department entity)
        {
           _context.Departments.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
