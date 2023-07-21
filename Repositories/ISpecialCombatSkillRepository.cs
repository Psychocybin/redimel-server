using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface ISpecialCombatSkillRepository
    {
        Task<SpecialCombatSkill?> GetByIdAsync(Guid id);
    }
}
