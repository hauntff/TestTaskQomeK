using AuthApi.Data;
using AuthApi.Interfaces;
using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Repos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AuthDbContext context) : base(context) { }
        public async Task<List<User>> GetAllUsers()
        {
            var newContext = (AuthDbContext)context;
            var users = await newContext.Users.ToListAsync();
            return users;
        }
        public User FindUserFromDb(string username)
        {
            var newContext = (AuthDbContext)context;
            var user =  newContext.Users.FirstOrDefault(x=>x.UserName== username);
            return user;
        }
    }
}
