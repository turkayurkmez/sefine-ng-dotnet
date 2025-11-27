using ProjectManagement.API.Models.DataTransferObjects;

namespace ProjectManagement.API.Services
{
    public interface IProjectService
    {
        Task<bool> CheckProject(int id);
        Task<int> CreateProject(CreateProjectRequest project);
        Task<ProjectResponse> GetById(int id);
        Task<List<ProjectResponse>> GetProjects();
        Task<List<ProjectResponse>> GetProjectsByDepartment(int departmentId);
        Task<List<ProjectWithTasksResponse>> GetProjectsWithTasks();
        Task<bool> Update(UpdateProjectRequest project);
        Task<bool> Delete(int id);
    }
}
