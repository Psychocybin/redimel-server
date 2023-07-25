using Microsoft.AspNetCore.Identity;

namespace redimel_server.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
