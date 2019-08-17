using Microsoft.EntityFrameworkCore;

namespace MySecureService.Models
{
    public class MyServiceContext : DbContext, IMyServiceContext
    {
        public MyServiceContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<MyRecords> MyRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyRecords>(u => u.HasKey(k => k.RecordId))
                .Entity<MyRecords>(u => u.Property(p => p.RecordId).IsRequired())
                .Entity<MyRecords>(u => u.Property(p => p.RecordName).IsRequired());
        }
    }
}
