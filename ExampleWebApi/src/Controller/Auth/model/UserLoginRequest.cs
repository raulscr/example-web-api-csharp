
namespace Auth.Controller.Model
{
    public class UserLoginRequest
    {
        public UserLoginRequest(string login = "", string password = "")
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}