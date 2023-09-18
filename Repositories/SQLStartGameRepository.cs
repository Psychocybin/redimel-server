using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                var currentChoice = PerformChange(currentUser, change).Result;

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

        public async Task<Choice> PerformChange(User user, Change change)
        {
            if (change.ClassName == "Abilities")
            {
                var hero = user.GroupWest.Heroes.FirstOrDefault(x => x.HeroType == change.HeroType);

                if (hero == null)
                {
                    throw new InvalidOperationException();
                }

                if (change.PropertyName == "Survival")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Survival == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Survival = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Survival = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Diplomacy")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Diplomacy == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Diplomacy = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Diplomacy = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Climbing")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Climbing == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Climbing = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Climbing = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Acrobatics")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Acrobatics == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Acrobatics = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Acrobatics = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Skill")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Skill == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Skill = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Skill = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Guile")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Guile == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Guile = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Guile = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "SecretKnowledge")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.SecretKnowledge == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.SecretKnowledge = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.SecretKnowledge = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Sneak")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Sneak == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Sneak = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Sneak = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Elusion")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Elusion == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Elusion = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Elusion = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "WaterCycle")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.WaterCycle == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.WaterCycle = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.WaterCycle = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Melee")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Melee == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Melee = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Melee = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "NatureSkills")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.NatureSkills == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.NatureSkills = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.NatureSkills = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "BreakingLocks")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.BreakingLocks == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.BreakingLocks = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.BreakingLocks = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Transformation")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Transformation == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Transformation = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Transformation = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Spells")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Spells == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Spells = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Spells = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Rituals")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Rituals == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Rituals = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Rituals = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Traps")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Traps == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Traps = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Traps = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Archery")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Archery == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Archery = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Archery = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "ThrowingKnives")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.ThrowingKnives == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.ThrowingKnives = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.ThrowingKnives = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "PoisonousNeedles")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.PoisonousNeedles == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.PoisonousNeedles = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.PoisonousNeedles = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Stimulants")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Stimulants == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Stimulants = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Stimulants = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Wrestling")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Wrestling == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Wrestling = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Wrestling = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Observation")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Observation == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Observation = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Observation = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "ShieldBearer")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.ShieldBearer == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.ShieldBearer = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.ShieldBearer = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "Leadership")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.Leadership == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.Leadership = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.Leadership = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "KickFight")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.KickFight == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.KickFight = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.KickFight = false;
                    }

                    return null;
                }
                else if (change.PropertyName == "DoubleStrike")
                {
                    if (change.ActionType == "check")
                    {
                        if (hero.Ability.DoubleStrike == true)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                    else if (change.ActionType == "add")
                    {
                        hero.Ability.DoubleStrike = true;
                    }
                    else if (change.ActionType == "remove")
                    {
                        hero.Ability.DoubleStrike = false;
                    }

                    return null;
                }
            }

            if (change.ClassName == "AditionalPoints")
            {
                var aditionalPoints = user.GroupWest.AditionalPoints;

                if (change.ActionType == "check")
                {
                    if (change.PropertyName == "TeamGame")
                    {
                        var teamGame = aditionalPoints.TeamGame;
                        var requiredTeamGame = change.Attack;
                        var indicator = change.AdditionalInfo;

                        if (indicator == "equal")
                        {
                            if (teamGame == requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "bigger")
                        {
                            if (teamGame >= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "less")
                        {
                            if (teamGame <= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                    }
                    else if (change.PropertyName == "ImportantInformation")
                    {
                        var importantInformation = aditionalPoints.ImportantInformation;
                        var requiredTeamGame = change.Attack;
                        var indicator = change.AdditionalInfo;

                        if (indicator == "equal")
                        {
                            if (importantInformation == requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "bigger")
                        {
                            if (importantInformation >= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "less")
                        {
                            if (importantInformation <= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                    }
                    else if (change.PropertyName == "SlainMonsters")
                    {
                        var slainMonsters = aditionalPoints.SlainMonsters;
                        var requiredTeamGame = change.Attack;
                        var indicator = change.AdditionalInfo;

                        if (indicator == "equal")
                        {
                            if (slainMonsters == requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "bigger")
                        {
                            if (slainMonsters >= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "less")
                        {
                            if (slainMonsters <= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                    }
                    else if (change.PropertyName == "Morals")
                    {
                        var morals = aditionalPoints.Morals;
                        var requiredTeamGame = change.Attack;
                        var indicator = change.AdditionalInfo;

                        if (indicator == "equal")
                        {
                            if (morals == requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "bigger")
                        {
                            if (morals >= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "less")
                        {
                            if (morals <= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                    }
                    else if (change.PropertyName == "Cover")
                    {
                        var cover = aditionalPoints.Cover;
                        var requiredTeamGame = change.Attack;
                        var indicator = change.AdditionalInfo;

                        if (indicator == "equal")
                        {
                            if (cover == requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "bigger")
                        {
                            if (cover >= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "less")
                        {
                            if (cover <= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                    }
                    else if (change.PropertyName == "TemporaryPoints")
                    {
                        var temporaryPoints = aditionalPoints.TemporaryPoints;
                        var requiredTeamGame = change.Attack;
                        var indicator = change.AdditionalInfo;

                        if (indicator == "equal")
                        {
                            if (temporaryPoints == requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "bigger")
                        {
                            if (temporaryPoints >= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                        else if (indicator == "less")
                        {
                            if (temporaryPoints <= requiredTeamGame)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }
                    }
                }
                else if (change.ActionType == "add")
                {
                    aditionalPoints.TeamGame += change.Attack;
                    aditionalPoints.ImportantInformation += change.Defence;
                    aditionalPoints.SlainMonsters += change.Damage;
                    aditionalPoints.Morals += Convert.ToInt32(change.Range);
                    aditionalPoints.Cover += Convert.ToInt32(change.Quantity);
                    aditionalPoints.TemporaryPoints += int.Parse(change.AdditionalInfo);
                }
                else if (change.ActionType == "remove")
                {
                    aditionalPoints.TeamGame -= change.Attack;
                    aditionalPoints.ImportantInformation -= change.Defence;
                    aditionalPoints.SlainMonsters -= change.Damage;
                    aditionalPoints.Morals -= Convert.ToInt32(change.Range);
                    aditionalPoints.Cover -= Convert.ToInt32(change.Quantity);
                    aditionalPoints.TemporaryPoints -= int.Parse(change.AdditionalInfo);
                }
            }

            return null;
        }
    }
}
