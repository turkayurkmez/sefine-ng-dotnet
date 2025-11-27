using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.API.Models
{
    public class Department : IDBEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Departman adını boş bırakmayınız...")]
        public string Name { get; set; }
        public ICollection<Project>? Projects { get; set; }

    }
}
