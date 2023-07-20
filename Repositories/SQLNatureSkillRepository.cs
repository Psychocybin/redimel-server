using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLNatureSkillRepository : INatureSkillRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLNatureSkillRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<NatureSkill>> GetAllAsync()
        {
            return await dbContext.NatureSkills.ToListAsync();
        }

        public async Task<NatureSkill?> GetByIdAsync(Guid id)
        {
            return await dbContext.NatureSkills.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
