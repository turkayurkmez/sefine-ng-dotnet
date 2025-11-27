using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.API.Models.DataTransferObjects
{
    public class UpdateProjectRequest
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proje adý gereklidir.")]
        [MaxLength(200, ErrorMessage = "Proje adý maksimum 200 karakter olabilir.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartedDate { get; set; }

        [Range(0, 1, ErrorMessage = "Tamamlanma yüzdesi 0 ile 1 arasýnda olmalýdýr.")]
        public double? CompletedPercent { get; set; }

        public int? DepartmentId { get; set; }
    }
}
