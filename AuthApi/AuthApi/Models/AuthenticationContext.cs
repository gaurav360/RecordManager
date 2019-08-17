using Microsoft.EntityFrameworkCore;

namespace AuthApi.Models
{
    public class AuthenticationContext : DbContext, IAuthenticationContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(u => u.HasKey(k => k.UserId))
                .Entity<User>(u => u.Property(p => p.UserId).IsRequired())
                .Entity<User>(u => u.Property(p => p.Password).IsRequired());
        }
    }
}
