using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLArmorRepository : IArmorRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLArmorRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Armor?> GetByIdAsync(Guid id)
        {
            return await dbContext.Armors.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
