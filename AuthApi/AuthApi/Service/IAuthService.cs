using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Models;

namespace AuthApi.Service
{
    public interface IAuthService
    {
        bool RegisterUser(User user);
        User LoginUser(string userId, string password);
    }
}
