namespace ProjectManagement.API.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public int? ProjectId { get; set; }
        public bool IsDone { get; set; }


        //navigation property
        public Project Project { get; set; }

    }
}
