using Microsoft.EntityFrameworkCore;

namespace AuthApi.Models
{
    public interface IAuthenticationContext
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();//need not to implement explicitly as it is implemented inside DBContext
    }
}
