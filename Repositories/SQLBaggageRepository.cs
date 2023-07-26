using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLBaggageRepository : IBaggageRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLBaggageRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //return await dbContext.Baggages.Where(x => x.HeroId.ToString() == user).ToListAsync();


        public async Task<Baggage> CreateAsync(Baggage baggage)
        {
            await dbContext.AddAsync(baggage);
            await dbContext.SaveChangesAsync();
            
            return baggage;
        }

        public async Task<Baggage?> DeleteAsync(Guid id)
        {
            var existingBaggage = await dbContext.Baggages.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBaggage == null)
            {
                return null;
            }

            dbContext.Baggages.Remove(existingBaggage);
            await dbContext.SaveChangesAsync();

            return existingBaggage;
        }

        public async Task<List<Baggage>> GetAllAsync()
        {
            return await dbContext.Baggages.ToListAsync();
        }

        public async Task<Baggage?> GetByIdAsync(Guid id)
        {
            return await dbContext.Baggages.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
