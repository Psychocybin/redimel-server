using static System.Runtime.InteropServices.JavaScript.JSType;

namespace redimel_server.Models.Domain
{
    public class Hero
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HeroClass { get; set; }
        public double BaggageCapacity { get; set; }
        public Guid PromisesId { get; set; }
        public Guid BaggagesId { get; set; }
        public Guid IndicatorsId { get; set; }
        public Guid EquipmentsId { get; set; }
        public Guid AbilitiesId { get; set; }
        public Guid SpecialAbilitiesId { get; set; }
        public ICollection<Baggage> Baggages { get; set; }
        public ICollection<Promise> Promises { get; set; }
        public Indicator Indicators { get; set; }
        public Equipment Equipments { get; set; }
        public Ability Abilities { get; set; }
        public SpecialAbility SpecialAbilities { get; set; }
    }
}
