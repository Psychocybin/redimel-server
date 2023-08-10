﻿namespace redimel_server.Models.DTO
{
    public class AddHeroDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HeroClass { get; set; }
        public int OrderOfBattle { get; set; }
        public double BaggageCapacity { get; set; }
        public Guid GroupWestId { get; set; }
        public Guid EquipmentsId { get; set; }
        public Guid AbilityId { get; set; }
        public Guid SpecialAbilityId { get; set; }
        public IndicatorDto Indicators { get; set; }
    }
}