using User.Repository.Model;

namespace User.Repository
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetUserByName(string userName);
    }
}