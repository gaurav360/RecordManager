using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Models;

namespace AuthApi.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IAuthenticationContext context;

        public AuthRepository(IAuthenticationContext _context)
        {
            context = _context;

        }
               
        public User FindUserById(string userId)
        {
            return context.Users.FirstOrDefault(x => x.UserId.Equals(userId));
        }

        public User LoginUser(string userId, string password)
        {
            var user = context.Users.FirstOrDefault(x => x.UserId.Equals(userId) && x.Password.Equals(password));
            return user;
        }

        public bool RegisterUser(User user)
        {
            var usr = context.Users.FirstOrDefault(x => x.UserId.Equals(user.UserId));
            if (usr != null)
            {
                return false;
            }

            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }
    }
}
