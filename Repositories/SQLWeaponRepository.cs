using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLWeaponRepository : IWeaponRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLWeaponRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Weapon?> GetByIdAsync(Guid id)
        {
            return await dbContext.Weapons.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
