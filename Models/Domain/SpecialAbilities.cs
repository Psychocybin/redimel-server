namespace redimel_server.Models.Domain
{
    public class SpecialAbilities
    {
        public Guid Id { get; set; }
        public Guid SpecialCombatSkillId { get; set; }
        public Guid UltimateId { get; set; }
        public Guid SpellsId { get; set; }
        public Guid RitualsId { get; set; }
        public Guid NatureSkillsId { get; set; }
        public SpecialCombatSkill SpecialCombatSkill { get; set; }
        public Ultimate Ultimate { get; set; }
        public ICollection<Spell> Spells { get; set; }
        public ICollection<Ritual> Rituals { get; set; }
        public ICollection<NatureSkill> NatureSkills { get; set; }
    }
}
