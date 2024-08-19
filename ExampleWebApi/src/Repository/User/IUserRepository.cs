using User.Repository.Model;

namespace User.Repository
{
    public interface IUserRepository {
        Task<UserLoginModel?> GetUserByName(string userName);
    }
}