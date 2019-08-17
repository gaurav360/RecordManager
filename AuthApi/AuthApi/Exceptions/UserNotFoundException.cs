using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Exceptions
{
    public class UserNotFoundException:ApplicationException
    {
        public UserNotFoundException() { }
        public UserNotFoundException(string userId, string pass):base($"User with this id {userId} and password {pass} does not exist") { }
    }
}
