using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectManagementDbContext _context;

        public ProjectRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Project> CreateAsync(Project entity)
        {
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
                if (project == null) return false;

                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects
                .Include(p => p.Department)
                .Include(p => p.Tasks)
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Department)
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> GetProjectsByDepartmentAsync(int departmentId)
        {
            return await _context.Projects
                .Include(p => p.Department)
                .Include(p => p.Tasks)
                .Where(p => p.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsWithTasksAsync()
        {
            return await _context.Projects
                .Include(p => p.Department)
                .Include(p => p.Tasks)
                .ToListAsync();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _context.Projects.AnyAsync(p => p.Id == id);
        }

        public async Task<Project?> UpdateAsync(Project entity)
        {
            _context.Projects.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
