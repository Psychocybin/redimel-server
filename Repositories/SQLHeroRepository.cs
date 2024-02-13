using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLHeroRepository : IHeroRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLHeroRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Hero>> GetAllAsync()
        {
            return await dbContext.Heroes.Include(x => x.Indicators).ToListAsync();
        }

        public async Task<Hero?> GetByIdAsync(Guid id)
        {
            return await dbContext.Heroes.Include(x => x.Indicators)
                .Include(x => x.Equipments).ThenInclude(x => x.Armor)
                .Include(x => x.Baggages).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
