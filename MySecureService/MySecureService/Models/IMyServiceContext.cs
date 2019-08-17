using Microsoft.EntityFrameworkCore;

namespace MySecureService.Models
{
    public interface IMyServiceContext
    {
        DbSet<MyRecords> MyRecords { get; set; }
        int SaveChanges();//need not to implement explicitly as it is implemented inside DBContext
    }
}
