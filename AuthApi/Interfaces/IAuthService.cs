using AuthApi.DTO;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Interfaces
{
    public interface IAuthService
    {
        Task<ActionResult<User>> Register(UserDto request);
        Task<ActionResult<string>> LogIn(UserDto request);
    }
}
