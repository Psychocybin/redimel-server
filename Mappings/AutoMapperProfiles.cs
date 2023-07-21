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
        }
    }
}
