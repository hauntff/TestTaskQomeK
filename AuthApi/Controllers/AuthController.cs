using AuthApi.DTO;
using AuthApi.Interfaces;
using Domain.Entity;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authservice;

        public AuthController(IConfiguration configuration, IAuthService authService)
        { 
            _configuration = configuration;
            _authservice = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            _authservice.Register(request);
            return Ok("all is ok");
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> LogIn(UserDto request)
        {
            return await _authservice.LogIn(request);
        }


    }
}
