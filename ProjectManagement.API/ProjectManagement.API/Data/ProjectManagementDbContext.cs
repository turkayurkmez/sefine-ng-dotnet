using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Models;
using Task = ProjectManagement.API.Models.Task;

namespace ProjectManagement.API.Data
{
    public class ProjectManagementDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }


        //1. DB nerede?
        //2. DB nasıl oluşuyor?

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Data Source=(localdb)\mssqllocaldb;Initial Catalog=SefineProjectsDB;Integrated Security=True;Encrypt=True
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=SefineProjectsDB;Integrated Security=True;Encrypt=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Property(p => p.Name).IsRequired()
                                                                .HasMaxLength(200);

            modelBuilder.Entity<Project>().HasOne(p => p.Department)
                                          .WithMany(d => d.Projects)
                                          .HasForeignKey(p => p.DepartmentId)
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Project>().HasMany(project => project.Tasks)
                                          .WithOne(task=>task.Project)
                                          .HasForeignKey(task=>task.ProjectId)
                                          .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Department>().HasData(
                new Department { Id=1, Name="İnsan Kaynakları"}
                );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id=1, Name="Çalışanlar Uygulaması", DepartmentId=1, CompletedPercent=0.10, StartedDate=new DateTime(2025,11,14) }
                );

            modelBuilder.Entity<Task>().HasData(
                new Task {  Id=1, Name="Angular uygulamasını tasarla", IsDone=false, ProjectId=1, Description="Angular bileşenleri tasarlanacak", ExpectedDate=new DateTime(2025,12,1)}
                );

                                          
        }
    }
}
