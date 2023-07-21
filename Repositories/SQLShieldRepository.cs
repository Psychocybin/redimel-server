using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLShieldRepository : IShieldRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLShieldRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Shield?> GetByIdAsync(Guid id)
        {
            return await dbContext.Shields.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
