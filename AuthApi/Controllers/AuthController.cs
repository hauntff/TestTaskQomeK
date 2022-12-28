using AuthApi.DTO;
using AuthApi.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IConfiguration configuration, IAuthService authService, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        { 
            _configuration = configuration;
            _authservice = authService;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var username = _authservice.GetMyName();
            return Ok(username);
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            User users =  _userRepository.FindUserFromDb(request.Username);
            if (users != null)
            {
                return BadRequest("a user with the given name already exists in the system");
            }
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
