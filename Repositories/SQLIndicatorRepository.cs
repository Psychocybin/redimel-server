using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLIndicatorRepository : IIndicatorRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLIndicatorRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Indicator>> GetAllAsync()
        {
            return await dbContext.Indicators.ToListAsync();
        }
    }
}
