using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLChoiceRepository : IChoiceRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLChoiceRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Choice> CreateAsync(Choice choice)
        {
            await dbContext.Choices.AddAsync(choice);
            await dbContext.SaveChangesAsync();
            return choice;
        }

        public async Task<Choice?> DeleteAsync(Guid id)
        {
            var existingChoice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == id);

            if (existingChoice == null)
            {
                return null;
            }

            dbContext.Choices.Remove(existingChoice);
            await dbContext.SaveChangesAsync();

            return existingChoice;
        }

        public async Task<List<Choice>> GetAllAsync()
        {
            return await dbContext.Choices.ToListAsync();
        }

        public async Task<List<Choice>> GetAllForCurrentPageByIdAsync(string id)
        {
            return await dbContext.Choices.Where(x => x.PageId == id).ToListAsync();
        }

        public async Task<Choice?> GetByIdAsync(Guid id)
        {
            return await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Choice?> UpdateAsync(Guid id, Choice choice)
        {
            var existingChoice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == id);

            if (existingChoice == null)
            {
                return null;
            }

            existingChoice.AdditionalCheck = choice.AdditionalCheck;
            existingChoice.Description = choice.Description;
            existingChoice.NextPage = choice.NextPage;
            existingChoice.PageId = choice.PageId;

            await dbContext.SaveChangesAsync();

            return existingChoice;
        }
    }
}
