using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Models;

namespace AuthApi.Repository
{
    public interface IAuthRepository
    {
        bool RegisterUser(User user);
        User LoginUser(string userId, string password);
        User FindUserById(string userId);
    }
}
