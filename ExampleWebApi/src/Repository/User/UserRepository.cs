using Microsoft.EntityFrameworkCore;

using User.Repository.DatabaseContext;
using User.Repository.Model;

namespace User.Repository
{
    public class UserRepository(ILogger<UserRepository> logger, UserContext context) : IUserRepository
    {
        private ILogger<UserRepository> _logger = logger;
        private UserContext _context = context;

        public async Task<UserEntity?> GetUserByName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == userName);
        }
    }
}