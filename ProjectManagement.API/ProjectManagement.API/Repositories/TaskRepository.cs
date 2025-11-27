using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;

namespace ProjectManagement.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ProjectManagementDbContext _context;

        public TaskRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Task> CreateAsync(Models.Task entity)
        {
            await _context.Tasks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
                if (task == null) return false;

                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Models.Task>> GetAllAsync()
        {
            return await _context.Tasks
                .Include(t => t.Project)
                .ToListAsync();
        }

        public async Task<Models.Task?> GetByIdAsync(int id)
        {
            return await _context.Tasks
                .Include(t => t.Project)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Models.Task>> GetTasksByProjectAsync(int projectId)
        {
            return await _context.Tasks
                .Include(t => t.Project)
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _context.Tasks.AnyAsync(t => t.Id == id);
        }

        public async Task<Models.Task?> UpdateAsync(Models.Task entity)
        {
            _context.Tasks.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
