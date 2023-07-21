using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.DTO
{
    public class HeroDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HeroClass { get; set; }
        public double BaggageCapacity { get; set; }
        public Guid GroupWestId { get; set; }
        public Guid IndicatorsId { get; set; }
        public Guid EquipmentsId { get; set; }
        public Guid AbilityId { get; set; }
        public Guid SpecialAbilityId { get; set; }
    }
}
