using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLTalismanRepository : ITalismanRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLTalismanRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Talisman>> GetAllAsync()
        {
            return await dbContext.Talismans.ToListAsync();
        }

        public async Task<Talisman?> GetByIdAsync(Guid id)
        {
            return await dbContext.Talismans.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
