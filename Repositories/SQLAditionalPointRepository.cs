using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLAditionalPointRepository : IAditionalPointRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLAditionalPointRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AditionalPoint?> GetByIdAsync(Guid id)
        {
            return await dbContext.AditionalPoints.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
