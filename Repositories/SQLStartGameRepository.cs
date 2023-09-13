using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;

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

        public async Task<Page> GetNextPageAsync(Choice choice)
        {
            var mandatoryChoices = await dbContext.Choices.Where(x => x.AdditionalCheck == false)
                .Where(x => x.PageId == choice.NextPage).ToListAsync();

            var currentUserEmail = userRepository.GetUserEmail();

            var currentUser = await dbContext.Users.Where(x => x.CurrentUserEmail == currentUserEmail)
                .Include(x => x.GroupWest).ThenInclude(x => x.AditionalPoints).ThenInclude(x => x.BattleGroups)
                .Include(x => x.GroupWest).ThenInclude(x => x.AditionalPoints).ThenInclude(x => x.Negotiations)
                .Include(x => x.GroupWest).ThenInclude(x => x.Missions)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Indicators)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Ability)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Baggages)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Promises)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.SpecialAbility).ThenInclude(x => x.SpecialCombatSkill)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.SpecialAbility).ThenInclude(x => x.Ultimate)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.SpecialAbility).ThenInclude(x => x.Spells)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.SpecialAbility).ThenInclude(x => x.Rituals)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.SpecialAbility).ThenInclude(x => x.NatureSkills)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Weapon)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Armor)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Shield)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.ThrowingWeapon)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Talismans)
                .Include(x => x.WorldInfoVariables).FirstOrDefaultAsync();

            if (choice.PageId != currentUser.CurrentLocation)
            {
                throw new Exception();
            }

            var nextPage = await dbContext.Pages.FirstOrDefaultAsync(x => x.Id == choice.NextPage);

            var choicesList = new List<Choice>();

            foreach (var item in mandatoryChoices)
            {
                choicesList.Add(item);
            }

            var changesList = await dbContext.Changes.Where(x => x.PageId == nextPage.Id).ToListAsync();

            foreach (var change in changesList)
            {
                var currentChoice = PerformChange(change);

                if (currentChoice != null)
                {
                    choicesList.Add(currentChoice);
                }
            }

            nextPage.Choices = choicesList;
            currentUser.CurrentLocation = nextPage.Id;

            await dbContext.SaveChangesAsync();

            return nextPage;



            //var country = nextPage.Id.Substring(3, 3);
            //var area = nextPage.Id.Substring(6, 3);
            //var place = nextPage.Id.Substring(9, 3);
            //var situation = nextPage.Id.Substring(12, 3);

            //if (country == "mag")
            //{
            //    if (area == "tow")
            //    {
            //        if (place == "lib")
            //        {
            //            if (situation == "001")
            //            {
            //                choicesList.Add(await dbContext.Choices.FirstOrDefaultAsync(x => x.Id.ToString() == "7D7F0A55-EA5C-4643-7534-08DBA497FC0E"));

            //                if (currentUser.GroupWest.Heroes.Any(x => x.HeroClass == "Soldier"))
            //                {
            //                    choicesList.Add(await dbContext.Choices.FirstOrDefaultAsync(x => x.Id.ToString() == "5BB83086-E234-4162-7535-08DBA497FC0E"));

            //                    currentUser.WorldInfoVariables.Add(new WorldInfoVariable
            //                    {
            //                        RedimelLocation = "redmagtowlib",
            //                        Name = "Guard",
            //                        Count = 1,
            //                        TrueOrFalse = true,
            //                        ActiveOrNot = true
            //                    });

            //                    currentUser.GroupWest.Heroes.First(x => x.HeroClass == "Soldier").Indicators.Health += 10;
            //                }

            //                nextPage.Choices = choicesList;
            //            }
            //            if (situation == "002")
            //            {
            //                if (currentUser.WorldInfoVariables.Any(x => x.Name == "Guard"))
            //                {
            //                    choicesList.Add(await dbContext.Choices.FirstOrDefaultAsync(x => x.Id.ToString() == "582871F4-9419-4FD6-7536-08DBA497FC0E"));
            //                }
            //            }
            //            if (situation == "003")
            //            {

            //            }
            //        }
            //        if (place == "cen")
            //        {
            //            if (situation == "")
            //            {

            //            }
            //        }
            //        if (place == "inn")
            //        {
            //            if (situation == "")
            //            {

            //            }
            //        }
            //        if (place == "gua")
            //        {
            //            if (situation == "")
            //            {

            //            }
            //        }
            //    }
            //}
            //else if (country == "out")
            //{

            //}
            //else
            //{
            //    throw new Exception();
            //}
        }

        private static Choice PerformChange(Change change)
        {
            if (change.ClassName == "Ability")
            {
                return null;
            }

            return null;
        }
    }
}
