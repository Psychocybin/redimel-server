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
            var existingPage = await dbContext.Pages.FirstOrDefaultAsync(x => x.Id == id);

            if (existingPage == null)
            {
                return null;
            }

            dbContext.Pages.Remove(existingPage);
            await dbContext.SaveChangesAsync();

            return existingPage;
        }

        public async Task<List<Page>> GetAllAsync()
        {
            return await dbContext.Pages.ToListAsync();
        }

        public async Task<Page?> GetByIdAsync(string id)
        {
            return await dbContext.Pages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Page?> UpdateAsync(string id, Page page)
        {
            var existingPage = await dbContext.Pages.FirstOrDefaultAsync(x => x.Id == id);

            if (existingPage == null)
            {
                return null;
            }

            existingPage.Description = page.Description;

            await dbContext.SaveChangesAsync();

            return existingPage;
        }
    }
}
