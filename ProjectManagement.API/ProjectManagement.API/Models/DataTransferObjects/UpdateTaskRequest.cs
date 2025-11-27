using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.API.Models.DataTransferObjects
{
    public class UpdateTaskRequest
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Görev adý gereklidir.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? ExpectedDate { get; set; }

        public int? ProjectId { get; set; }

        public bool IsDone { get; set; }
    }
}
