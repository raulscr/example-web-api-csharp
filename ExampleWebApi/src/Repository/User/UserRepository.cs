using Microsoft.EntityFrameworkCore;

using User.Repository.DatabaseContext;
using User.Repository.Model;

namespace User.Repository
{
    public class UserRepository : DbContext, IUserRepository
    {
        private ILogger<UserRepository> _logger;
        private UserContext _context;

        public UserRepository(ILogger<UserRepository> logger, UserContext context) 
        {
            _logger = logger;
            _context = context;
        }

        public async Task<UserLoginModel?> GetUserByName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == userName);
        }
    }
}