namespace ProjectManagement.API.Models.DataTransferObjects
{
    public class ProjectWithTasksResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartedDate { get; set; }
        public double? CompletedPercent { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int TaskCount { get; set; }
        public int CompletedTaskCount { get; set; }
        public List<TaskResponse> Tasks { get; set; } = new List<TaskResponse>();
    }
}
