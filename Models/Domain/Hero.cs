namespace redimel_server.Models.Domain
{
    public class Hero
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HeroClass { get; set; }
        public int BaggageCapacity { get; set; }
        public IDictionary<string, double> Baggage { get; set; }
        public IDictionary<string, Boolean> Promises { get; set; }
        public Guid IndicatorsId { get; set; }
        public Guid EquipmentId { get; set; }
        public Guid AbilitiesId { get; set; }
        public Guid SpecialAbilitiesId { get; set; }
        public Indicators Indicators { get; set; }
        public Equipment Equipment { get; set; }
        public Abilities Abilities { get; set; }
        public SpecialAbilities SpecialAbilities { get; set; }
    }
}
