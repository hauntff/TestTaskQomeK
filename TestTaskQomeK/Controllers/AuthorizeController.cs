using AuthApi.DTO;
using AuthApi.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace TestTaskQomeK.Controllers
{
    public class AuthorizeController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public AuthorizeController(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
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
		public JsonResult LogIn(string username, string password)
		{
			UserDto user = new UserDto();
			user.Username = username;
			user.Password = password;
			var answer =_authService.LogIn(user);
			return Json(answer.Result.Value);
		}
	}
}
