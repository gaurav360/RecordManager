using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Exceptions;
using AuthApi.Models;
using AuthApi.Repository;

namespace AuthApi.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository repository;
        
        public AuthService(IAuthRepository _repository)
        {
            this.repository = _repository;
        }
        public User LoginUser(string userId, string password)
        {
            var user = repository.LoginUser(userId, password);
            if (user == null)
            {
                throw new UserNotFoundException(userId, password);
            }

            return user;
        }

        public bool RegisterUser(User user)
        {
            if(repository.RegisterUser(user))
            {
                return true;
            }

            throw new UserNotCreatedException(user.UserId);
        }
    }
}
