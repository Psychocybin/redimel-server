using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class Ultimate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int RequiredMentalEnergy { get; set; }
        //[ForeignKey("SpecialAbilities")]
        public Guid SpecialAbilitiesId { get; set; }
        //public SpecialAbility SpecialAbilities { get; set; }
    }
}
