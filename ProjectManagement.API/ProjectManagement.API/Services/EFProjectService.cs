using ProjectManagement.API.Models;
using ProjectManagement.API.Models.DataTransferObjects;
using ProjectManagement.API.Repositories;

namespace ProjectManagement.API.Services
{
    public class EFProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public EFProjectService(IProjectRepository projectRepository)
        {
            _repository = projectRepository;
        }

        public async Task<bool> CheckProject(int id)
        {
            return await _repository.IsExistsAsync(id);
        }

        public async Task<int> CreateProject(CreateProjectRequest request)
        {
            Project project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                StartedDate = request.StartedDate,
                CompletedPercent = request.CompletedPercent,
                DepartmentId = request.DepartmentId
            };
            var createdProject = await _repository.CreateAsync(project);
            return createdProject.Id;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProjectResponse> GetById(int id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null) return null;

            return MapToProjectResponse(project);
        }

        public async Task<List<ProjectResponse>> GetProjects()
        {
            var projects = await _repository.GetAllAsync();
            return projects.Select(p => MapToProjectResponse(p)).ToList();
        }

        public async Task<List<ProjectResponse>> GetProjectsByDepartment(int departmentId)
        {
            var projects = await _repository.GetProjectsByDepartmentAsync(departmentId);
            return projects.Select(p => MapToProjectResponse(p)).ToList();
        }

        public async Task<List<ProjectWithTasksResponse>> GetProjectsWithTasks()
        {
            var projects = await _repository.GetProjectsWithTasksAsync();
            return projects.Select(p => MapToProjectWithTasksResponse(p)).ToList();
        }

        public async Task<bool> Update(UpdateProjectRequest projectRequest)
        {
            var project = new Project
            {
                Id = projectRequest.Id,
                Name = projectRequest.Name,
                Description = projectRequest.Description,
                StartedDate = projectRequest.StartedDate,
                CompletedPercent = projectRequest.CompletedPercent,
                DepartmentId = projectRequest.DepartmentId
            };
            var projectUpdated = await _repository.UpdateAsync(project);
            return projectUpdated != null;
        }

        private ProjectResponse MapToProjectResponse(Project project)
        {
            return new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartedDate = project.StartedDate,
                CompletedPercent = project.CompletedPercent,
                DepartmentId = project.DepartmentId,
                DepartmentName = project.Department?.Name,
                TaskCount = project.Tasks?.Count ?? 0,
                CompletedTaskCount = project.Tasks?.Count(t => t.IsDone) ?? 0
            };
        }

        private ProjectWithTasksResponse MapToProjectWithTasksResponse(Project project)
        {
            return new ProjectWithTasksResponse
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartedDate = project.StartedDate,
                CompletedPercent = project.CompletedPercent,
                DepartmentId = project.DepartmentId,
                DepartmentName = project.Department?.Name,
                TaskCount = project.Tasks?.Count ?? 0,
                CompletedTaskCount = project.Tasks?.Count(t => t.IsDone) ?? 0,
                Tasks = project.Tasks?.Select(t => new TaskResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    ExpectedDate = t.ExpectedDate,
                    ProjectId = t.ProjectId,
                    ProjectName = project.Name,
                    IsDone = t.IsDone
                }).ToList() ?? new List<TaskResponse>()
            };
        }
    }
}
