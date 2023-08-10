using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLStartGameRepository : IStartGameRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLStartGameRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Page> GetNextPage(Choice choice)
        {
            //check User.CurrentLocation == pageId

            //if (choice.NextPage == null && choice.PageId == null)
            //{
            //    throw new Exception();
            //}


            var nextPage = await dbContext.Pages.FirstOrDefaultAsync(x => x.Id == choice.NextPage);
            var choicesList = await dbContext.Choices.Where(x => x.PageId == nextPage.Id).ToListAsync();
            nextPage.Choices = choicesList;

            //User.CurrentLocation = nextPage.Id

            return nextPage;
        }
    }
}
