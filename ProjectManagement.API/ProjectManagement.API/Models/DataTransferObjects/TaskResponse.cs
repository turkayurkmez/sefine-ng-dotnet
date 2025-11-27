namespace ProjectManagement.API.Models.DataTransferObjects
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public int? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public bool IsDone { get; set; }
    }
}
