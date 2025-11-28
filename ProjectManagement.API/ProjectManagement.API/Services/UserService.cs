using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>
        {
            new User { Id =1, Username ="ahmetyilmaz", Email="ahmet.yilmaz@example.com", Role="Admin", Password="admin123" },
            new User { Id =2, Username ="mehmetdemir", Email="mehmet.demir@example.com", Role="Editor", Password="editor123" },
            new User { Id =3, Username ="aysekaya", Email="ayse.kaya@example.com", Role="User", Password="user123" }
        };


        public User ValidateUser(string username, string password)
        {
            return users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }

    }
}
