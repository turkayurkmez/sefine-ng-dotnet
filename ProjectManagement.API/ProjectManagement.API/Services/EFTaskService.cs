using ProjectManagement.API.Models.DataTransferObjects;
using ProjectManagement.API.Repositories;

namespace ProjectManagement.API.Services
{
    public class EFTaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public EFTaskService(ITaskRepository taskRepository)
        {
            _repository = taskRepository;
        }

        public async Task<bool> CheckTask(int id)
        {
            return await _repository.IsExistsAsync(id);
        }

        public async Task<int> CreateTask(CreateTaskRequest request)
        {
            Models.Task task = new Models.Task
            {
                Name = request.Name,
                Description = request.Description,
                ExpectedDate = request.ExpectedDate,
                ProjectId = request.ProjectId,
                IsDone = request.IsDone
            };
            var createdTask = await _repository.CreateAsync(task);
            return createdTask.Id;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<TaskResponse> GetById(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return null;

            return MapToTaskResponse(task);
        }

        public async Task<List<TaskResponse>> GetTasks()
        {
            var tasks = await _repository.GetAllAsync();
            return tasks.Select(t => MapToTaskResponse(t)).ToList();
        }

        public async Task<List<TaskResponse>> GetTasksByProject(int projectId)
        {
            var tasks = await _repository.GetTasksByProjectAsync(projectId);
            return tasks.Select(t => MapToTaskResponse(t)).ToList();
        }

        public async Task<bool> ToggleTaskStatus(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return false;

            task.IsDone = !task.IsDone;
            var updatedTask = await _repository.UpdateAsync(task);
            return updatedTask != null;
        }

        public async Task<bool> Update(UpdateTaskRequest taskRequest)
        {
            var task = new Models.Task
            {
                Id = taskRequest.Id,
                Name = taskRequest.Name,
                Description = taskRequest.Description,
                ExpectedDate = taskRequest.ExpectedDate,
                ProjectId = taskRequest.ProjectId,
                IsDone = taskRequest.IsDone
            };
            var taskUpdated = await _repository.UpdateAsync(task);
            return taskUpdated != null;
        }

        private TaskResponse MapToTaskResponse(Models.Task task)
        {
            return new TaskResponse
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                ExpectedDate = task.ExpectedDate,
                ProjectId = task.ProjectId,
                ProjectName = task.Project?.Name,
                IsDone = task.IsDone
            };
        }
    }
}
