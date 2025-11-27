using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.API.Models.DataTransferObjects
{
    public class CreateDepartmentRequest
    {
        [Required(ErrorMessage ="Departman adını giriniz...")]
        public string Name { get; set; }
    }
}
