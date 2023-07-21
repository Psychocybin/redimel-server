using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLUltimateRepository : IUltimateRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLUltimateRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Ultimate?> GetByIdAsync(Guid id)
        {
            return await dbContext.Ultimates.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
