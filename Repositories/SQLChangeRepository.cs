using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLChangeRepository : IChangeRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLChangeRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Change> CreateAsync(Change change)
        {
            await dbContext.Changes.AddAsync(change);
            await dbContext.SaveChangesAsync();
            return change;
        }

        public async Task<Change?> DeleteAsync(Guid id)
        {
            var existingChange = await dbContext.Changes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingChange == null)
            {
                return null;
            }

            dbContext.Changes.Remove(existingChange);
            await dbContext.SaveChangesAsync();

            return existingChange;
        }

        public async Task<List<Change>> GetAllAsync()
        {
            return await dbContext.Changes.ToListAsync();
        }

        public async Task<Change?> GetByIdAsync(Guid id)
        {
            return await dbContext.Changes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Change?> UpdateAsync(Guid id, Change change)
        {
            var existingChange = await dbContext.Changes.FirstOrDefaultAsync(i => i.Id == id);

            if (existingChange == null)
            {
                return null;
            }

            existingChange.ClassName = change.ClassName;
            existingChange.PropertyName = change.PropertyName;
            existingChange.ActionType = change.ActionType;
            existingChange.HeroClass = change.HeroClass;
            existingChange.HeroType = change.HeroType;
            existingChange.OrderOfBattle = change.OrderOfBattle;
            existingChange.PageId = change.PageId;
            existingChange.ChoiceId = change.ChoiceId;
            existingChange.Name = change.Name;
            existingChange.Description = change.Description;
            existingChange.AdditionalInfo = change.AdditionalInfo;
            existingChange.TrueOrFalse = change.TrueOrFalse;
            existingChange.ActiveOrNot = change.ActiveOrNot;
            existingChange.Attack = change.Attack;
            existingChange.Defence = change.Defence;
            existingChange.Damage = change.Damage;
            existingChange.Range = change.Range;
            existingChange.Quantity = change.Quantity;

            await dbContext.SaveChangesAsync();

            return existingChange;
        }
    }
}
