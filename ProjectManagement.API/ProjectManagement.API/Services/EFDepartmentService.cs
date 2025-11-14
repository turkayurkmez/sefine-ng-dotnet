using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    public class EFDepartmentService : IDepartmentService
    {
        private readonly ProjectManagementDbContext dbContext;

        public EFDepartmentService(ProjectManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Department> GetDepartments()
        {
            var departments = dbContext.Departments.ToList();    
            return departments;
        }
    }
}
