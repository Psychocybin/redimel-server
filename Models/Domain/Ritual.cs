namespace redimel_server.Models.Domain
{
    public class Ritual
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int RequiredMentalEnergy { get; set; }
        public Guid SpecialAbilityId { get; set; }
        public SpecialAbility SpecialAbility { get; set; }
    }
}
