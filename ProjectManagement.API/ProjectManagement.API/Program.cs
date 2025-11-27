//1. Kýsým: uygulama çalýþýrken kullanýlacak nesnelerin yapýlandýrmalarý
using ProjectManagement.API.Data;
using ProjectManagement.API.Repositories;
using ProjectManagement.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    //yeni bir "poliçe" oluþtur. Yanýtlar için bu poliçeyi kullanacaksýn.
    opt.AddPolicy("allow", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();

       // builder.WithOrigins("https://www.turkayurkmez.com");

        /*
         * https://sefine.com.tr/
         * https://www.sefine.com.tr/
         * http://sefine.com.tr/
         * https://sefine.com.tr:8080
         */
    });
});

// Dependency Injection kayýtlarý
builder.Services.AddScoped<IDepartmentService, EFDepartmentService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddScoped<IProjectService, EFProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<ITaskService, EFTaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddDbContext<ProjectManagementDbContext>();



var app = builder.Build();

//2. Kýsým: http istekleri üzerinde yapýlacak genel iþlemler

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allow");

app.UseAuthorization();

app.MapControllers();

app.Run();
