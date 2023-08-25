using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class SpecialAbility
    {
        public Guid Id { get; set; }
        public Guid HeroId { get; set; }
        [ForeignKey("SpecialCombatSkill")]
        public Guid SpecialCombatSkillId { get; set; }
        [ForeignKey("Ultimate")]
        public Guid UltimateId { get; set; }
        public virtual SpecialCombatSkill SpecialCombatSkill { get; set; }
        public virtual Ultimate Ultimate { get; set; }
        public virtual ICollection<Spell> Spells { get; set; }
        public virtual ICollection<Ritual> Rituals { get; set; }
        public virtual ICollection<NatureSkill> NatureSkills { get; set; }
    }
}
