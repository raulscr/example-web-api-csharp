using System.Text.Json.Serialization;

namespace Auth.Controller.Model
{
    public class UserLoginRequest(string login = "", string password = "")
    {
        [JsonPropertyName("login")]
        public string Login { get; set; } = login;

        [JsonPropertyName("password")]
        public string Password { get; set; } = password;
    }
}