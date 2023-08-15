using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;
using redimel_server.Models.Domain.RedimelDomain;
using redimel_server.Models.Domain.RedimelDomain.MagelandDomain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace redimel_server.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ClaimsPrincipal user;
        private readonly RedimelServerDbContext dbContext;

        public SQLUserRepository(RedimelServerDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;
            this.dbContext = dbContext;
            //var userMail = httpContextAccessor.HttpContext?.User.Claims.Single(a => a.Type == ClaimTypes.Email).Value;
        }

        public async Task<User> CreateUserAsync(string heroEmail, GroupWestHeroes groupWestHeroes)
        {
            var newUserId = Guid.NewGuid();
            var redimelId = Guid.NewGuid();
            var groupWestId = Guid.NewGuid();

            var magelandId = Guid.NewGuid();
            var theHorsePeopleId = Guid.NewGuid();
            var dikaniId = Guid.NewGuid();
            var tumpridadamId = Guid.NewGuid();
            var theOldKingdomId = Guid.NewGuid();
            var theHigherOnesId = Guid.NewGuid();
            var theTradeLeagueId = Guid.NewGuid();
            var faegraId = Guid.NewGuid();
            var theEmpireId = Guid.NewGuid();
            var theBigCityId = Guid.NewGuid();
            var stincumId = Guid.NewGuid();
            var thePirateDomainsId = Guid.NewGuid();
            var theIslandersId = Guid.NewGuid();
            var theForestTribesId = Guid.NewGuid();
            var southernNomadsId = Guid.NewGuid();
            var northernNomadsId = Guid.NewGuid();
            var theHuntersId = Guid.NewGuid();
            var outlawTerritoryId = Guid.NewGuid();
            var theWastelandId = Guid.NewGuid();
            var theShadowWorldId = Guid.NewGuid();

            var mageTownId = Guid.NewGuid();
            var mageTradeRoadId = Guid.NewGuid();
            var mageSeaId = Guid.NewGuid();
            var mageHarborId = Guid.NewGuid();
            var mageForestId = Guid.NewGuid();
            var mageFieldsId = Guid.NewGuid();
            var mageTownTheCentralSquareId = Guid.NewGuid();
            var mageTownInnTheOldMagicianId = Guid.NewGuid();
            var mageTownTheLibraryId = Guid.NewGuid();
            var mageTownGuardHillId = Guid.NewGuid();

            var aditionalPointsId = Guid.NewGuid();

            var newUser = new User
            {
                Id = newUserId,
                CurrentLocation = "redmagtowlib001",
                Checkpoint = "redmagtowlib001",
                TimeCounter = 1,
                CurrentUserEmail = heroEmail,
                RedimelId = redimelId,
                GroupWestId = groupWestId,
                Redimel = new Redimel
                {
                    Id = redimelId,
                    UserId = newUserId,
                    TheHorsePeopleId = theHorsePeopleId,
                    DikaniId = dikaniId,
                    MagelandId = magelandId,
                    TumpridadamId = tumpridadamId,
                    TheOldKingdomId = theOldKingdomId,
                    TheHigherOnesId = theHigherOnesId,
                    TheTradeLeagueId = theTradeLeagueId,
                    FaegraId = faegraId,
                    TheEmpireId = theEmpireId,
                    TheBigCityId = theBigCityId,
                    StincumId = stincumId,
                    ThePirateDomainsId = thePirateDomainsId,
                    TheIslandersId = theIslandersId,
                    TheForestTribesId = theForestTribesId,
                    SouthernNomadsId = southernNomadsId,
                    NorthernNomadsId = northernNomadsId,
                    TheHuntersId = theHuntersId,
                    OutlawTerritoryId = outlawTerritoryId,
                    TheWastelandId = theWastelandId,
                    TheShadowWorldId = theShadowWorldId,
                    TheHorsePeople = new TheHorsePeople
                    {
                        Id = theHorsePeopleId,
                        RedimelId = redimelId
                    },
                    Dikani = new Dikani
                    {
                        Id = dikaniId,
                        RedimelId = redimelId
                    },
                    Magelands = new Mageland
                    {
                        Id = magelandId,
                        RedimelId = redimelId,
                        MageTownId = mageTownId,
                        MageTradeRoadId = mageTradeRoadId,
                        MageSeaId = mageSeaId,
                        MageHarborId = mageHarborId,
                        MageForestId = mageForestId,
                        MageFieldsId = mageFieldsId,
                        MageTown = new MageTown
                        {
                            Id = mageTownId,
                            MagelandId = magelandId,
                            MageTownTheCentralSquareId = mageTownTheCentralSquareId,
                            MageTownInnTheOldMagicianId = mageTownInnTheOldMagicianId,
                            MageTownTheLibraryId = mageTownTheLibraryId,
                            MageTownGuardHillId = mageTownGuardHillId,
                            MageTownTheCentralSquare = new MageTownTheCentralSquare
                            {
                                Id = mageTownTheCentralSquareId,
                                MageTownId = mageTownId,
                                MageTownTheCentralSquareVariables = new List<WorldInfoVariable>()
                            },
                            MageTownInnTheOldMagician = new MageTownInnTheOldMagician
                            {
                                Id = mageTownInnTheOldMagicianId,
                                MageTownId = mageTownId,
                                MageTownOldMagicianVariables = new List<WorldInfoVariable>()
                            },
                            MageTownTheLibrary = new MageTownTheLibrary
                            {
                                Id = mageTownTheLibraryId,
                                MageTownId = mageTownId,
                                MageTownTheLibraryVariables = new List<WorldInfoVariable>()
                            },
                            MageTownGuardHill = new MageTownGuardHill
                            {
                                Id = mageTownGuardHillId,
                                MageTownId = mageTownId,
                                MageTownGuardHillVariables = new List<WorldInfoVariable>()
                            },
                            MageTownVariables = new List<WorldInfoVariable>()
                        },
                        MageTradeRoad = new MageTradeRoad
                        {
                            Id = mageTradeRoadId,
                        },
                        MageSea = new MageSea
                        {
                            Id = mageSeaId
                        },
                        MageHarbor = new MageHarbor
                        {
                            Id = mageHarborId,
                        },
                        MageForest = new MageForest
                        {
                            Id = mageForestId,
                        },
                        MageFields = new MageFields
                        {
                            Id = mageFieldsId,
                        },
                        MagelandVariables = new List<WorldInfoVariable>()
                    },
                    Tumpridadam = new Tumpridadam
                    {
                        Id = tumpridadamId,
                        RedimelId = redimelId
                    },
                    TheOldKingdom = new TheOldKingdom
                    {
                        Id = theOldKingdomId,
                        RedimelId = redimelId
                    },
                    TheHigherOnes = new TheHigherOnes
                    {
                        Id = theHigherOnesId,
                        RedimelId = redimelId
                    },
                    TheTradeLeague = new TheTradeLeague
                    {
                        Id = theTradeLeagueId,
                        RedimelId = redimelId
                    },
                    Faegra = new Faegra
                    {
                        Id = faegraId,
                        RedimelId = redimelId
                    },
                    TheEmpire = new TheEmpire
                    {
                        Id = theEmpireId,
                        RedimelId = redimelId
                    },
                    TheBigCity = new TheBigCity
                    {
                        Id = theBigCityId,
                        RedimelId = redimelId
                    },
                    Stincum = new Stincum
                    {
                        Id = stincumId,
                        RedimelId = redimelId
                    },
                    ThePirateDomains = new ThePirateDomains
                    {
                        Id = thePirateDomainsId,
                        RedimelId = redimelId
                    },
                    TheIslanders = new TheIslanders
                    {
                        Id = theIslandersId,
                        RedimelId = redimelId
                    },
                    TheForestTribes = new TheForestTribes
                    {
                        Id = theForestTribesId,
                        RedimelId = redimelId
                    },
                    SouthernNomads = new SouthernNomads
                    {
                        Id = southernNomadsId,
                        RedimelId = redimelId
                    },
                    NorthernNomads = new NorthernNomads
                    {
                        Id = northernNomadsId,
                        RedimelId = redimelId
                    },
                    TheHunters = new TheHunters
                    {
                        Id = theHuntersId,
                        RedimelId = redimelId
                    },
                    OutlawTerritory = new OutlawTerritory
                    {
                        Id = outlawTerritoryId,
                        RedimelId = redimelId
                    },
                    TheWasteland = new TheWasteland
                    {
                        Id = theWastelandId,
                        RedimelId = redimelId
                    },
                    TheShadowWorld = new TheShadowWorld
                    {
                        Id = theShadowWorldId,
                        RedimelId = redimelId
                    },
                    RedimelVariables = new List<WorldInfoVariable>()
                },
                GroupWest = new GroupWest
                {
                    Id = groupWestId,
                    UserId = newUserId,
                    ActualMission = "",
                    AditionalPointsId = aditionalPointsId,
                    AditionalPoints = new AditionalPoint
                    {
                        Id = aditionalPointsId,
                        TeamGame = 1,
                        ImportantInformation = 0,
                        SlainMonsters = 0,
                        Morals = 2,
                        Cover = 2,
                        GroupWestId = groupWestId,
                        BattleGroups = new List<BattleGroup>(),
                        Negotiations = new List<Negotiation>()
                    },
                    Missions = new List<Mission>(),
                    Heroes = new List<Hero>()
                }
            };

            var heroesList = new List<Hero>
            {
                await CreateHero(groupWestHeroes.FirstHero, groupWestId),
                await CreateHero(groupWestHeroes.SecondHero, groupWestId),
                await CreateHero(groupWestHeroes.ThirdHero, groupWestId),
                await CreateHero(groupWestHeroes.FourthHero, groupWestId)
            };

            newUser.GroupWest.Heroes = heroesList;

            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();

            return newUser;
        }

        public string GetUserEmail()
        {
            var currentUserEmail = this.user?.FindFirstValue(ClaimTypes.Email);
            return currentUserEmail;
        }

        private async Task<Hero> CreateHero(string heroType, Guid groupWestId)
        {
            var originalHero = await dbContext.Heroes.Include(x => x.Indicators).Include(x => x.Ability)
                .Include(x => x.Equipments).ThenInclude(x => x.Weapon)
                .Include(x => x.Equipments).ThenInclude(x => x.Shield)
                .Include(x => x.Equipments).ThenInclude(x => x.ThrowingWeapon)
                .Include(x => x.Equipments).ThenInclude(x => x.Armor)
                .Include(x => x.SpecialAbility).ThenInclude(x => x.SpecialCombatSkill)
                .Include(x => x.SpecialAbility).ThenInclude(x => x.Ultimate)
                .FirstOrDefaultAsync(x => x.HeroClass == heroType);

            var heroId = Guid.NewGuid();
            var indicatorsId = Guid.NewGuid();
            var equipmentsId = Guid.NewGuid();
            var abilityId = Guid.NewGuid();
            var specialAbilityId = Guid.NewGuid();
            var specialCombatSkillId = Guid.NewGuid();
            var ultimateId = Guid.NewGuid();
            var armorId = Guid.NewGuid();
            var shieldId = Guid.NewGuid();
            var weaponId = Guid.NewGuid();
            var throwingWeaponId = Guid.NewGuid();

            var newHero = new Hero
            {
                Id = heroId,
                Name = originalHero.Name,
                HeroClass = originalHero.HeroClass,
                OrderOfBattle = 0,
                BaggageCapacity = originalHero.BaggageCapacity,
                GroupWestId = groupWestId,
                IndicatorsId = indicatorsId,
                EquipmentsId = equipmentsId,
                AbilityId = abilityId,
                SpecialAbilityId = specialAbilityId,
                Indicators = new Indicator
                {
                    Id = indicatorsId,
                    Health = originalHero.Indicators.Health,
                    MentalEnergy = originalHero.Indicators.MentalEnergy,
                    MentalStrength = originalHero.Indicators.MentalStrength,
                    Strength = originalHero.Indicators.Strength,
                    Dexterity = originalHero.Indicators.Dexterity,
                    Agility = originalHero.Indicators.Agility,
                    Evasion = originalHero.Indicators.Evasion,
                    Endurance = originalHero.Indicators.Endurance,
                    HeroId = heroId
                },
                Equipments = new Equipment
                {
                    Id = equipmentsId,
                    Knife = originalHero.Equipments.Knife,
                    SmokeBall = originalHero.Equipments.SmokeBall,
                    Poison = originalHero.Equipments.Poison,
                    MedicPack = originalHero.Equipments.MedicPack,
                    MoneyBag = originalHero.Equipments.MoneyBag,
                    HeroId = heroId,
                    ArmorId = armorId,
                    ShieldId = shieldId,
                    WeaponId = weaponId,
                    ThrowingWeaponId = throwingWeaponId,
                    Armor = new Armor
                    {
                        Id = armorId,
                        ArmorType = originalHero.Equipments.Armor.ArmorType,
                        IsExist = originalHero.Equipments.Armor.IsExist,
                        Defence = originalHero.Equipments.Armor.Defence,
                        EquipmentId = equipmentsId
                    },
                    Shield = new Shield
                    {
                        Id = shieldId,
                        ShieldType = originalHero.Equipments.Shield.ShieldType,
                        IsExist = originalHero.Equipments.Shield.IsExist,
                        Defence = originalHero.Equipments.Shield.Defence,
                        EquipmentId = equipmentsId
                    },
                    Weapon = new Weapon
                    {
                        Id = weaponId,
                        WeaponType = originalHero.Equipments.Weapon.WeaponType,
                        IsExist = originalHero.Equipments.Weapon.IsExist,
                        IsItTwoHandWeapon = originalHero.Equipments.Weapon.IsItTwoHandWeapon,
                        Attack = originalHero.Equipments.Weapon.Attack,
                        Defence = originalHero.Equipments.Weapon.Defence,
                        Damage = originalHero.Equipments.Weapon.Damage,
                        WeaponRange = originalHero.Equipments.Weapon.WeaponRange,
                        EquipmentId = equipmentsId
                    },
                    ThrowingWeapon = new ThrowingWeapon
                    {
                        Id = throwingWeaponId,
                        ThrowingWeaponType = originalHero.Equipments.ThrowingWeapon.ThrowingWeaponType,
                        IsExist = originalHero.Equipments.ThrowingWeapon.IsExist,
                        Attack = originalHero.Equipments.ThrowingWeapon.Attack,
                        Defence = originalHero.Equipments.ThrowingWeapon.Defence,
                        Damage = originalHero.Equipments.ThrowingWeapon.Damage,
                        Quantity = originalHero.Equipments.ThrowingWeapon.Quantity,
                        ThrowingWeaponRange = originalHero.Equipments.ThrowingWeapon.ThrowingWeaponRange,
                        EquipmentId = equipmentsId
                    },
                    Talismans = new List<Talisman>()
                },
                Ability = new Ability
                {
                    Id = abilityId,
                    Survival = originalHero.Ability.Survival,
                    Diplomacy = originalHero.Ability.Diplomacy,
                    Climbing = originalHero.Ability.Climbing,
                    Acrobatics = originalHero.Ability.Acrobatics,
                    Skill = originalHero.Ability.Skill,
                    Guile = originalHero.Ability.Guile,
                    SecretKnowledge = originalHero.Ability.SecretKnowledge,
                    Sneak = originalHero.Ability.Sneak,
                    Elusion = originalHero.Ability.Elusion,
                    WaterCycle = originalHero.Ability.WaterCycle,
                    Melee = originalHero.Ability.Melee,
                    NatureSkills = originalHero.Ability.NatureSkills,
                    BreakingLocks = originalHero.Ability.BreakingLocks,
                    Transformation = originalHero.Ability.Transformation,
                    Spells = originalHero.Ability.Spells,
                    Rituals = originalHero.Ability.Rituals,
                    Traps = originalHero.Ability.Traps,
                    Archery = originalHero.Ability.Archery,
                    ThrowingKnives = originalHero.Ability.ThrowingKnives,
                    PoisonousNeedles = originalHero.Ability.PoisonousNeedles,
                    Stimulants = originalHero.Ability.Stimulants,
                    Wrestling = originalHero.Ability.Wrestling,
                    Observation = originalHero.Ability.Observation,
                    ShieldBearer = originalHero.Ability.ShieldBearer,
                    HeroId = heroId
                },
                SpecialAbility = new SpecialAbility
                {
                    Id = specialAbilityId,
                    HeroId = heroId,
                    SpecialCombatSkillId = specialCombatSkillId,
                    UltimateId = ultimateId,
                    SpecialCombatSkill = new SpecialCombatSkill
                    {
                        Id = specialCombatSkillId,
                        Name = originalHero.SpecialAbility.SpecialCombatSkill.Name,
                        SkillLevel = originalHero.SpecialAbility.SpecialCombatSkill.SkillLevel,
                        RequiredMentalEnergy = originalHero.SpecialAbility.SpecialCombatSkill.RequiredMentalEnergy,
                        SpecialAbilitiesId = specialAbilityId
                    },
                    Ultimate = new Ultimate
                    {
                        Id = ultimateId,
                        Name = originalHero.SpecialAbility.Ultimate.Name,
                        SkillLevel = originalHero.SpecialAbility.Ultimate.SkillLevel,
                        RequiredMentalEnergy = originalHero.SpecialAbility.Ultimate.RequiredMentalEnergy,
                        SpecialAbilitiesId = specialAbilityId
                    },
                    Spells = new List<Spell>(),
                    Rituals = new List<Ritual>(),
                    NatureSkills = new List<NatureSkill>()
                },
                Baggages = new List<Baggage>(),
                Promises = new List<Promise>()
            };

            return newHero;
        }

        //private int GetOrderOfBattle(string orderInput)
        //{
        //    int orderResult = 0;

        //    if (orderInput == "first")
        //    {
        //        orderResult = 1;
        //        return orderResult;
        //    }
        //    else if (orderInput == "second")
        //    {
        //        orderResult = 2;
        //        return orderResult;
        //    }
        //    else if (orderInput == "third")
        //    {
        //        orderResult = 3;
        //        return orderResult;
        //    }
        //    else if (orderInput == "fourth")
        //    {
        //        orderResult = 4;
        //        return orderResult;
        //    }

        //    return orderResult;
        //}
    }
}
