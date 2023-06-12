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
        public SpecialAbilityPoints SpecialCombatSkill { get; set; }
        public SpecialAbilityPoints Ultimate { get; set; }
        public ICollection<SpecialAbilityPoints> Spells { get; set; }
        public ICollection<SpecialAbilityPoints> Rituals { get; set; }
        public ICollection<SpecialAbilityPoints> NatureSkills { get; set; }
    }
}
