using Microsoft.AspNetCore.Identity;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IUserRepository
    {
        string GetUserEmail();
        Task<User> CreateUserAsync(string name);
    }
}
