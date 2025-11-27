using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.API.Models.DataTransferObjects
{
    public class CreateTaskRequest
    {
        [Required(ErrorMessage = "Görev adý gereklidir.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? ExpectedDate { get; set; }

        [Required(ErrorMessage = "Proje ID'si gereklidir.")]
        public int ProjectId { get; set; }

        public bool IsDone { get; set; } = false;
    }
}
