using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class SpecialAbility
    {
        public Guid Id { get; set; }
        //[ForeignKey("Hero")]
        public Guid HeroId { get; set; }
        [ForeignKey("SpecialCombatSkill")]
        public Guid SpecialCombatSkillId { get; set; }
        [ForeignKey("Ultimate")]
        public Guid UltimateId { get; set; }
        //public Hero Hero { get; set; }
        public SpecialCombatSkill SpecialCombatSkill { get; set; }
        public Ultimate Ultimate { get; set; }
        public ICollection<Spell> Spells { get; set; }
        public ICollection<Ritual> Rituals { get; set; }
        public ICollection<NatureSkill> NatureSkills { get; set; }
    }
}
