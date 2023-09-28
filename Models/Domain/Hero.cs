using redimel_server.Models.Enums;
using redimel_server.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class Hero
    {
        public Hero()
        {
            this.OrderOfBattle = RedimelConstants.ORDEROFBATTLE;
            this.Baggages = new List<Baggage>();
            this.Promises = new List<Promise>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public HeroClass HeroClass { get; set; }
        public HeroType HeroType { get; set; }
        public OrderOfBattle OrderOfBattle { get; set; }
        public double BaggageCapacity { get; set; }
        public Guid GroupWestId { get; set; }
        [ForeignKey("Indicators")]
        public Guid IndicatorsId { get; set; }
        [ForeignKey("Equipments")]
        public Guid EquipmentsId { get; set; }
        [ForeignKey("Ability")]
        public Guid AbilityId { get; set; }
        [ForeignKey("SpecialAbility")]
        public Guid SpecialAbilityId { get; set; }
        public virtual GroupWest GroupWest { get; set; }
        public virtual Indicator Indicators { get; set; }
        public virtual Equipment Equipments { get; set; }
        public virtual Ability Ability { get; set; }
        public virtual SpecialAbility SpecialAbility { get; set; }
        public virtual ICollection<Baggage> Baggages { get; set; }
        public virtual ICollection<Promise> Promises { get; set; }
    }
}
