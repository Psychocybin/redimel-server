using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLMissionRepository : IMissionRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLMissionRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Mission>> GetAllAsync()
        {
            return await dbContext.Missions.ToListAsync();
        }

        public async Task<Mission?> GetByIdAsync(Guid id)
        {
            return await dbContext.Missions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
