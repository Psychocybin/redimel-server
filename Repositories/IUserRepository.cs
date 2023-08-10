using Microsoft.AspNetCore.Identity;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IUserRepository
    {
        string GetUserId();
        Task<User> CreateUserAsync(string name);
    }
}
