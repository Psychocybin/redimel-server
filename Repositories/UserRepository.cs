using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;
using System.Security.Claims;

namespace redimel_server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RedimelServerAuthDbContext authDbContext;
        private readonly ClaimsPrincipal user;

        public UserRepository(RedimelServerAuthDbContext authDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.authDbContext = authDbContext;
            this.user = httpContextAccessor.HttpContext?.User;
        }

        public async Task<User> CreateUserAsync(string heroClass)
        {
            //TO DO
            authDbContext.Users.Select(x => x.Id);
            var newUser = new User();

            return newUser;
        }

        public string GetUserId()
        {
            //TO DO

            var currentUser = this.user?.FindFirstValue(ClaimTypes.NameIdentifier);
            return currentUser;
        }


    }
}
