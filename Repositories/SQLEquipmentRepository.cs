using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLEquipmentRepository : IEquipmentRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLEquipmentRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Equipment?> GetByIdAsync(Guid id)
        {
            return await dbContext.Equipments.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
