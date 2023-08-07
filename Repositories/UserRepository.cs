using Microsoft.AspNetCore.Identity;
using redimel_server.Data;

namespace redimel_server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityUser user;
        private readonly RedimelServerAuthDbContext authDbContext;

        public UserRepository(IdentityUser user, RedimelServerAuthDbContext authDbContext)
        {
            this.user = user;
            this.authDbContext = authDbContext;
        }

        public string GetUserId()
        {
            var currentUser = this.user.Id;
            
            return currentUser;
        }


    }
}
