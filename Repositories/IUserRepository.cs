using Microsoft.AspNetCore.Identity;

namespace redimel_server.Repositories
{
    public interface IUserRepository
    {
        string GetUserId();
    }
}
