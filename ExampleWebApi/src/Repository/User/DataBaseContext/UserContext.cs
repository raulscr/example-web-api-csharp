using Microsoft.EntityFrameworkCore;

using User.Repository.Model;

namespace User.Repository.DatabaseContext
{
    public class UserContext : DbContext
    {
        public DbSet<UserLoginModel> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) 
            : base(options)
        {
        }
    }
}