namespace ProjectManagement.API.Repositories
{
    public interface ITaskRepository : IRepository<Models.Task>
    {
        Task<IEnumerable<Models.Task>> GetTasksByProjectAsync(int projectId);


    }
}
