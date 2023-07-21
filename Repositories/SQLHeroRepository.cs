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

        public async Task<Hero?> GetByIdAsync(Guid id)
        {
            return await dbContext.Heroes.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
