using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Service
{
    public interface ITokenGenerator
    {
        string GetJwtToken(string userId, string role);
    }
}
