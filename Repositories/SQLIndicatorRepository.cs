using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;

namespace redimel_server.Repositories
{
    public class SQLIndicatorRepository : IIndicatorRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLIndicatorRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Indicator> CreateAsync(Indicator indicator)
        {
            await dbContext.Indicators.AddAsync(indicator);
            await dbContext.SaveChangesAsync();
            return indicator;
        }

        public async Task<Indicator?> DeleteAsync(Guid id)
        {
            var existingIndicator = await dbContext.Indicators.FirstOrDefaultAsync(x => x.Id == id);

            if (existingIndicator == null)
            {
                return null;
            }

            dbContext.Indicators.Remove(existingIndicator);
            await dbContext.SaveChangesAsync();

            return existingIndicator;
        }

        public async Task<List<Indicator>> GetAllAsync()
        {
            return await dbContext.Indicators.ToListAsync();
        }

        public async Task<Indicator?> GetByIdAsync(Guid id)
        {
            return await dbContext.Indicators.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Indicator?> UpdateAsync(Guid id, Indicator indicator)
        {
            var existingIndicator = await dbContext.Indicators.FirstOrDefaultAsync(i => i.Id == id);

            if (existingIndicator == null)
            {
                return null;
            }

            existingIndicator.Health = indicator.Health;
            existingIndicator.MentalEnergy = indicator.MentalEnergy;
            existingIndicator.MentalStrength = indicator.MentalStrength;
            existingIndicator.Strength = indicator.Strength;
            existingIndicator.Dexterity = indicator.Dexterity;
            existingIndicator.Agility = indicator.Agility;
            existingIndicator.Evasion = indicator.Evasion;
            existingIndicator.Endurance = indicator.Endurance;

            await dbContext.SaveChangesAsync();

            return existingIndicator;
        }
    }
}
