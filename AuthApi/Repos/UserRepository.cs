using AuthApi.Data;
using AuthApi.Interfaces;
using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace AuthApi.Repos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AuthDbContext context) : base(context) { }
    }
}
