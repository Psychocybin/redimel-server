using AutoMapper;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;

namespace redimel_server.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Indicator, IndicatorDto>().ReverseMap();
            CreateMap<AddIndicatorRequestDto, Indicator>().ReverseMap();
            CreateMap<UpdateIndicatorRequestDto, Indicator>().ReverseMap();
            CreateMap<AddBaggageRequestDto, Baggage>().ReverseMap();
            CreateMap<Baggage, BaggageDto>().ReverseMap();
            CreateMap<NatureSkill, NatureSkillDto>().ReverseMap();
            CreateMap<Ability, AbilityDto>().ReverseMap();
            CreateMap<AditionalPoint, AditionalPointDto>().ReverseMap();
            CreateMap<Armor, ArmorDto>().ReverseMap();
            CreateMap<Equipment, EquipmentDto>().ReverseMap();
            CreateMap<Hero, HeroDto>().ReverseMap();
            CreateMap<Mission, MissionDto>().ReverseMap();
            CreateMap<Negotiation, NegotiationDto>().ReverseMap();
            CreateMap<Promise, PromiseDto>().ReverseMap();
            CreateMap<Ritual, RitualDto>().ReverseMap();
            CreateMap<Shield, ShieldDto>().ReverseMap();
            CreateMap<SpecialCombatSkill, SpecialCombatSkillDto>().ReverseMap();
            CreateMap<Spell, SpellDto>().ReverseMap();
            CreateMap<Talisman, TalismanDto>().ReverseMap();
            CreateMap<ThrowingWeapon, ThrowingWeaponDto>().ReverseMap();
            CreateMap<Ultimate, UltimateDto>().ReverseMap();
            CreateMap<Weapon, WeaponDto>().ReverseMap();
            CreateMap<PageDto, Page>().ReverseMap();
            CreateMap<AddPageRequestDto, Page>().ReverseMap();
            CreateMap<UpdatePageRequestDto, Page>().ReverseMap();
            CreateMap<ChoiceDto, Choice>().ReverseMap();
            CreateMap<AddChoiceRequestDto, Choice>().ReverseMap();
            CreateMap<UpdateChoiceRequestDto, Choice>().ReverseMap();
            CreateMap<AddGroupWestHeroesRequestDto, GroupWestHeroes>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UpdateUserRequestDto, User>().ReverseMap();
            CreateMap<BattlePointDto, BattlePoint>().ReverseMap();
            CreateMap<AddRedimelInfoRequestDto, RedimelInfo>().ReverseMap();
            CreateMap<UpdateRedimelInfoRequestDto, RedimelInfo>().ReverseMap();
            CreateMap<RedimelInfoDto, RedimelInfo>().ReverseMap();
            CreateMap<ChangeDto, Change>().ReverseMap();
            CreateMap<UpdateChangeRequestDto, Change>().ReverseMap();
            CreateMap<AddChangeRequestDto, Change>().ReverseMap();
        }
    }
}
