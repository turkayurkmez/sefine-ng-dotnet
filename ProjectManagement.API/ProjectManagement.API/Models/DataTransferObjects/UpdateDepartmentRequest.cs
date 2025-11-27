using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.API.Models.DataTransferObjects
{
    public class UpdateDepartmentRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Departman adı gereklidir.")]
        public string Name { get; set; }
    }
}
