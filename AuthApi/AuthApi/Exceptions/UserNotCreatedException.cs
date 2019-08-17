using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Exceptions
{
    public class UserNotCreatedException:ApplicationException
    {
        public UserNotCreatedException() { }
        public UserNotCreatedException(string userId):base($"User with this id {userId} already exists") { }
    }
}
