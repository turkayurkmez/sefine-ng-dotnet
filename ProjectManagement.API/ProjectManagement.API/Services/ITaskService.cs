using ProjectManagement.API.Models.DataTransferObjects;

namespace ProjectManagement.API.Services
{
    public interface ITaskService
    {
        Task<bool> CheckTask(int id);
        Task<int> CreateTask(CreateTaskRequest task);
        Task<TaskResponse> GetById(int id);
        Task<List<TaskResponse>> GetTasks();
        Task<List<TaskResponse>> GetTasksByProject(int projectId);
        Task<bool> Update(UpdateTaskRequest task);
        Task<bool> Delete(int id);
        Task<bool> ToggleTaskStatus(int id);
    }
}
