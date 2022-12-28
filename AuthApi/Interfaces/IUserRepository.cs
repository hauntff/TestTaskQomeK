using Domain.Entity;
using Infrastructure.Interfaces;

namespace AuthApi.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllUsers();
        User FindUserFromDb(string username);
    }
}
