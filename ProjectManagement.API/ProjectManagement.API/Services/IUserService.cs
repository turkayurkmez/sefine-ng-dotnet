using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
    }
}