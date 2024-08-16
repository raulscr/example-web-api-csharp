
namespace Auth.Controller.Model
{
    public class UserLoginModel
    {
        public UserLoginModel(string login = "", string password = "")
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}