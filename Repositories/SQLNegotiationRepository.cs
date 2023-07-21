using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLNegotiationRepository : INegotiationRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLNegotiationRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Negotiation>> GetAllAsync()
        {
            return await dbContext.Negotiations.ToListAsync();
        }

        public async Task<Negotiation?> GetByIdAsync(Guid id)
        {
            return await dbContext.Negotiations.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
