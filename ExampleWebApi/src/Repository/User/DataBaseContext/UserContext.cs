using Microsoft.EntityFrameworkCore;

using User.Repository.Model;

namespace User.Repository.DatabaseContext
{
    public class UserContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Login)
                .IsUnique();
        }
    }
}