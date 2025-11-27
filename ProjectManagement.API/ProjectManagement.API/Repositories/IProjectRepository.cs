using ProjectManagement.API.Models;

namespace ProjectManagement.API.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IEnumerable<Project>> GetProjectsWithTasksAsync();
        Task<IEnumerable<Project>> GetProjectsByDepartmentAsync(int departmentId);
    }
}
