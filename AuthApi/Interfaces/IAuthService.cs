using AuthApi.DTO;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthApi.Interfaces
{
    public interface IAuthService
    {
        ClaimsIdentity CreateClaim(User user);

		string GetMyName();

		Task<ActionResult<User>> Register(UserDto request);
        Task<ActionResult<string>> LogIn(UserDto request);
    }
}
