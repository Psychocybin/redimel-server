using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLSpellRepository : ISpellRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLSpellRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Spell>> GetAllAsync()
        {
            return await dbContext.Spells.ToListAsync();
        }

        public async Task<Spell?> GetByIdAsync(Guid id)
        {
            return await dbContext.Spells.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
