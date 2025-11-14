namespace ProjectManagement.API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public DateTime? StartedDate {  get; set; }

        public double? CompletedPercent { get; set; }
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }

        public List<Task> Tasks { get; set; }



    }
}
