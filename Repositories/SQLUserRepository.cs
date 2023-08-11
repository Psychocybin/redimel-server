using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;
using System.Security.Claims;

namespace redimel_server.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly RedimelServerAuthDbContext authDbContext;
        private readonly ClaimsPrincipal user;

        public SQLUserRepository(RedimelServerAuthDbContext authDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.authDbContext = authDbContext;
            this.user = httpContextAccessor.HttpContext?.User;
            //var userMail = httpContextAccessor.HttpContext?.User.Claims.Single(a => a.Type == ClaimTypes.Email).Value;
        }

        public async Task<User> CreateUserAsync(string heroEmail)
        {
            var newUser = new User();

            //TO DO

            return newUser;
        }

        public string GetUserEmail()
        {
            var currentUserEmail = this.user?.FindFirstValue(ClaimTypes.Email);
            return currentUserEmail;
        }


    }
}
