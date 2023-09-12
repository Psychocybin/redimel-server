using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLRedimelInfoRepository : IRedimelInfoRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLRedimelInfoRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<RedimelInfo> CreateAsync(RedimelInfo redimelInfo)
        {
            await dbContext.RedimelInfos.AddAsync(redimelInfo);
            await dbContext.SaveChangesAsync();

            return redimelInfo;
        }

        public async Task<RedimelInfo?> DeleteAsync(Guid id)
        {
            var existingRedimelInfo = await dbContext.RedimelInfos.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRedimelInfo == null)
            {
                return null;
            }

            dbContext.RedimelInfos.Remove(existingRedimelInfo);
            await dbContext.SaveChangesAsync();

            return existingRedimelInfo;
        }

        public async Task<List<RedimelInfo>> GetAllAsync()
        {
            return await dbContext.RedimelInfos.ToListAsync();
        }

        public async Task<RedimelInfo?> GetByIdAsync(Guid id)
        {
            return await dbContext.RedimelInfos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RedimelInfo?> UpdateAsync(Guid id, RedimelInfo redimelInfo)
        {
            var existingRedimelInfo = await dbContext.RedimelInfos.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRedimelInfo == null)
            {
                return null;
            }

            existingRedimelInfo.Title = redimelInfo.Title;
            existingRedimelInfo.Description = redimelInfo.Description;
            existingRedimelInfo.AdditionalInfo = redimelInfo.AdditionalInfo;

            await dbContext.SaveChangesAsync();

            return existingRedimelInfo;
        }
    }
}
