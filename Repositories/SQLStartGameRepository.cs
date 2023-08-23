using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;
using System.Linq.Expressions;

namespace redimel_server.Repositories
{
    public class SQLStartGameRepository : IStartGameRepository
    {
        private readonly RedimelServerDbContext dbContext;
        private readonly IUserRepository userRepository;

        public SQLStartGameRepository(RedimelServerDbContext dbContext, IUserRepository userRepository)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
        }

        public async Task<Page> GetNextPage(Choice choice)
        {
            var currentUserEmail = userRepository.GetUserEmail();
            var currentUser = await dbContext.Users
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Weapon)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Armor)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.ThrowingWeapon)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Shield)
                .FirstOrDefaultAsync(x => x.CurrentUserEmail == currentUserEmail);

            

            //var currentUser = await dbContext.Users.Include(x => x.Redimel).ThenInclude(x => x.Magelands).ThenInclude(x => x.MageTown)
            //    .ThenInclude(x => x.MageTownTheLibrary).ThenInclude(x => x.MageTownTheLibraryVariables)
            //    .FirstOrDefaultAsync(x => x.CurrentUserEmail == currentUserEmail);

            if (choice.PageId != currentUser.CurrentLocation)
            {
                throw new Exception();
            }

            var nextPage = await dbContext.Pages.FirstOrDefaultAsync(x => x.Id == choice.NextPage);

            var choicesList = new List<Choice>();

            var country = nextPage.Id.Substring(3, 3);
            var area = nextPage.Id.Substring(6, 3);
            var place = nextPage.Id.Substring(9, 3);
            var situation = nextPage.Id.Substring(12, 3);

            if (country == "mag")
            {
                if (area == "tow")
                {
                    if (place == "lib")
                    {
                        if (situation == "001")
                        {
                            choicesList.Add(await dbContext.Choices.FirstOrDefaultAsync(x => x.Id.ToString() == "665C1F43-F725-4054-5640-08DBA3B46D02"));

                            //var variableElement = currentUser.Redimel.Magelands.MageTown.MageTownTheLibrary.MageTownTheLibraryVariables
                            //    .Where(x => x.Name == "guard").FirstOrDefault().ToString();

                            //if (variableElement == "guard")
                            //{
                            //    choicesList.Add(await dbContext.Choices.FirstOrDefaultAsync(x => x.Id.ToString() == "D0926C39-BB5C-4A05-5641-08DBA3B46D02"));
                            //}

                            var element = await dbContext.Users.Where(x => x.CurrentUserEmail == currentUserEmail).Select(x => x.GroupWest)
                                .Select(x => x.Heroes.Where(y => y.HeroClass == "Soldier")).FirstOrDefaultAsync();

                            if (element.ToString() == "Soldier")
                            {
                                currentUser.GroupWest.Heroes.First(x => x.HeroClass == "Soldier").Indicators.Health -= 30;
                                choicesList.Add(await dbContext.Choices.FirstOrDefaultAsync(x => x.Id.ToString() == "1B88E04E-E5A6-49B3-5642-08DBA3B46D02"));
                            }

                            nextPage.Choices = choicesList;
                        }
                        if (situation == "002")
                        {

                        }
                        if (situation == "003")
                        {

                        }
                    }
                    if (place == "cen")
                    {
                        if (situation == "")
                        {

                        }
                    }
                    if (place == "inn")
                    {
                        if (situation == "")
                        {

                        }
                    }
                    if (place == "gua")
                    {
                        if (situation == "")
                        {

                        }
                    }
                }
            }
            else if (country == "out")
            {

            }
            else
            {
                throw new Exception();
            }

            currentUser.CurrentLocation = nextPage.Id;
            await dbContext.SaveChangesAsync();

            return nextPage;
        }


    }
}
