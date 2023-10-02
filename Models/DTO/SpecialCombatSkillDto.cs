﻿using redimel_server.Models.Enums;

namespace redimel_server.Models.DTO
{
    public class SpecialCombatSkillDto
    {
        public Guid Id { get; set; }
        public SpecialCombatSkillType Name { get; set; }
        public int SkillLevel { get; set; }
        public int RequiredMentalEnergy { get; set; }
        public Guid SpecialAbilitiesId { get; set; }
    }
}
