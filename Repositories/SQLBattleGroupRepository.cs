using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLBattleGroupRepository : IBattleGroupRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLBattleGroupRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BattleGroup?> GetByIdAsync(Guid id)
        {
            return await dbContext.BattleGroups.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
