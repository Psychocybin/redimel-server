namespace redimel_server.Models.DTO
{
    public class RitualDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int RequiredMentalEnergy { get; set; }
        public Guid SpecialAbilityId { get; set; }
    }
}
