using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> departments;
        public DepartmentService()
        {
            departments = new List<Department>
            {
                new Department { Id =1, Name ="Bilgi Teknolojileri"},
                new Department { Id =2, Name ="İnsan Kaynakları"},
                new Department { Id =3, Name ="Satın Alma"},
                new Department { Id =4, Name ="Pazarlama"}
            };
        }

        public List<Department> GetDepartments()
        {
            return departments;
        }
    }
}
