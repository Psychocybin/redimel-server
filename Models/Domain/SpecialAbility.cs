namespace redimel_server.Models.Domain
{
    public class SpecialAbility
    {
        public Guid Id { get; set; }
        public Guid SpecialCombatSkillsId { get; set; }
        public Guid UltimatesId { get; set; }
        public Guid SpellsId { get; set; }
        public Guid RitualsId { get; set; }
        public Guid NatureSkillsId { get; set; }
        public SpecialCombatSkill SpecialCombatSkills { get; set; }
        public Ultimate Ultimates { get; set; }
        public ICollection<Spell> Spells { get; set; }
        public ICollection<Ritual> Rituals { get; set; }
        public ICollection<NatureSkill> NatureSkills { get; set; }
    }
}
