using AuthApi.DTO;
using AuthApi.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace TestTaskQomeK.Controllers
{
    public class AuthorizeController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        public AuthorizeController(IAuthService authService, IUserRepository userRepository, IHttpClientFactory httpClientFactory)
        {
            _authService = authService;
            _userRepository = userRepository;
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(string username, string password)
        {
            UserDto user = new UserDto();
			User users =  _userRepository.FindUserFromDb(username);
			if (users != null)
			{
				return BadRequest("a user with the given name already exists in the system");
			}
			user.Username = username;
            user.Password = password;
            _authService.Register(user);
            return RedirectToAction("Index","Home");
        }
		public async Task<JsonResult> LogIn(UserDto user)
		{

            var users = _userRepository.FindUserFromDb(user.Username);
			var answer = await _authService.LogIn(user);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true
            };
            Response.Cookies.Append("Authorization", answer.Value, cookieOptions);
            _authService.CreateClaim(users);
			return Json(answer.Value);
		}
	}
}
