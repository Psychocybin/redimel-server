using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLPageRepository : IPageRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLPageRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Page> CreateAsync(Page page)
        {
            await dbContext.Pages.AddAsync(page);
            await dbContext.SaveChangesAsync();
            return page;
        }

        public async Task<Page?> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Page>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Page?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Page?> UpdateAsync(string id, Page page)
        {
            throw new NotImplementedException();
        }
    }
}
