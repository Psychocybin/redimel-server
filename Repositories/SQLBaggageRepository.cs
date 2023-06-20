using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLBaggageRepository : IBaggageRepository
    {
        private readonly DbContext dbContext;

        public SQLBaggageRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Baggage> CreateAsync(Baggage baggage)
        {
            await dbContext.AddAsync(baggage);
            await dbContext.SaveChangesAsync();
            
            return baggage;
        }
    }
}
