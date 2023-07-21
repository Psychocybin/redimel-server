using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLThrowingWeaponRepository : IThrowingWeaponRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLThrowingWeaponRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ThrowingWeapon?> GetByIdAsync(Guid id)
        {
            return await dbContext.ThrowingWeapons.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
