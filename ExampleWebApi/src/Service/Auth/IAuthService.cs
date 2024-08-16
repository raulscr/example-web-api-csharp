using Microsoft.AspNetCore.Identity.Data;

using Auth.Service.Model;

namespace Auth.Service
{
    public interface IAuthService
    {
        string Login(UserLoginModel user);
    }
}