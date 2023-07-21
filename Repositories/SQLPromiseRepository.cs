using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLPromiseRepository : IPromiseRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLPromiseRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Promise>> GetAllAsync()
        {
            return await dbContext.Promises.ToListAsync();
        }

        public async Task<Promise?> GetByIdAsync(Guid id)
        {
            return await dbContext.Promises.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
