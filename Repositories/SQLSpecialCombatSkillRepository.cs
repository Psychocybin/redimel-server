using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLSpecialCombatSkillRepository : ISpecialCombatSkillRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLSpecialCombatSkillRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<SpecialCombatSkill?> GetByIdAsync(Guid id)
        {
            return await dbContext.SpecialCombatSkills.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
