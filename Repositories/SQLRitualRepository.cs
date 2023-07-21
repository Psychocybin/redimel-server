using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLRitualRepository : IRitualRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLRitualRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Ritual>> GetAllAsync()
        {
            return await dbContext.Rituals.ToListAsync();
        }

        public async Task<Ritual?> GetByIdAsync(Guid id)
        {
            return await dbContext.Rituals.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
