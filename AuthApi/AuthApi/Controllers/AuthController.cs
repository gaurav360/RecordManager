using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Exceptions;
using AuthApi.Models;
using AuthApi.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("auth")]    
    public class AuthController : Controller
    {
        private readonly IAuthService service;
        private readonly ITokenGenerator tokenGenerator;

        public AuthController(IAuthService _service, ITokenGenerator _tokenGenerator = null)
        {
            service = _service;
            tokenGenerator = _tokenGenerator;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]User user)
        {
            try
            {
                //Need to send token after login.
                var usr = service.LoginUser(user.UserId, user.Password);
                if (usr != null && tokenGenerator != null)
                {
                    var token = tokenGenerator.GetJwtToken(usr.UserId, usr.Role);
                    this.HttpContext.Response.Headers.Add("BearerToken", token);
                }
                usr.Password = null;
                return Ok(usr);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server Error ");
            }
        }

        [HttpPost]
        [Route("register")]        
        public IActionResult Register([FromBody]User user)
        {
            try
            {
                return Created("", service.RegisterUser(user));
            }
            catch (UserNotCreatedException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error Occured");
            }
        }

        [HttpGet]
        [Route("health")]
        public IActionResult HealthCheck()
        {
            return Ok("Auth service is running successfully");
        }

    }
}
