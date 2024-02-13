using redimel_server.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.DTO
{
    public class SpecialAbilityDto
    {
        public Guid Id { get; set; }
        public Guid HeroId { get; set; }
        public Guid SpecialCombatSkillId { get; set; }
        public Guid UltimateId { get; set; }
        public SpecialCombatSkillDto SpecialCombatSkill { get; set; }
        public UltimateDto Ultimate { get; set; }
        public List<SpellDto> Spells { get; set; }
        public List<RitualDto> Rituals { get; set; }
        public List<NatureSkillDto> NatureSkills { get; set; }
    }
}
