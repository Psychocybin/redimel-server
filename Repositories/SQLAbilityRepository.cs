using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLAbilityRepository : IAbilityRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLAbilityRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Ability>> GetAllAsync()
        {
            return await dbContext.Abilities.ToListAsync();
        }

        public async Task<Ability?> GetByIdAsync(Guid id)
        {
            return await dbContext.Abilities.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
