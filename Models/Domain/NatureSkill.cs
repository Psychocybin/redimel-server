namespace redimel_server.Models.Domain
{
    public class NatureSkill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int RequiredMentalEnergy { get; set; }
    }
}
