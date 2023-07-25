using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace redimel_server.Data
{
    public class RedimelServerAuthDbContext : IdentityDbContext
    {
        public RedimelServerAuthDbContext(DbContextOptions<RedimelServerAuthDbContext> options) : base(options)
        {

        }
    }
}
