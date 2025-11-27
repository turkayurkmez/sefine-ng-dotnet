namespace ProjectManagement.API.Models
{
    public class Department : IDBEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
