using redimel_server.Models.Enums;

namespace redimel_server.Models.DTO
{
    public class HeroDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public HeroClass HeroClass { get; set; }
        public HeroType HeroType { get; set; }
        public OrderOfBattle OrderOfBattle { get; set; }
        public double BaggageCapacity { get; set; }
        public Guid GroupWestId { get; set; }
        public Guid EquipmentsId { get; set; }
        public Guid AbilityId { get; set; }
        public Guid SpecialAbilityId { get; set; }
        public IndicatorDto Indicators { get; set; }
        public AbilityDto Ability { get; set; }
        public SpecialAbilityDto SpecialAbility { get; set; }
        public EquipmentDto Equipments { get; set; }
        public List<BaggageDto> Baggages { get; set; }
        public List<PromiseDto> Promises { get; set; }
    }
}
