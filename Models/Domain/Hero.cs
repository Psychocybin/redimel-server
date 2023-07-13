using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace redimel_server.Models.Domain
{
    public class Hero
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HeroClass { get; set; }
        public double BaggageCapacity { get; set; }
        [ForeignKey("GroupWest")]
        public Guid GroupWestId { get; set; }
        [ForeignKey("Indicators")]
        public Guid IndicatorsId { get; set; }
        [ForeignKey("Equipments")]
        public Guid EquipmentsId { get; set; }
        [ForeignKey("Ability")]
        public Guid AbilityId { get; set; }
        [ForeignKey("SpecialAbility")]
        public Guid SpecialAbilityId { get; set; }
        public GroupWest GroupWest { get; set; }
        public Indicator Indicators { get; set; }
        public Equipment Equipments { get; set; }
        public Ability Ability { get; set; }
        public SpecialAbility SpecialAbility { get; set; }
        public ICollection<Baggage> Baggages { get; set; }
        public ICollection<Promise> Promises { get; set; }
    }
}
