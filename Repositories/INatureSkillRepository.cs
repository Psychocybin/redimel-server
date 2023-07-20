using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface INatureSkillRepository
    {
        Task<List<NatureSkill>> GetAllAsync();

        Task<NatureSkill?> GetByIdAsync(Guid id);
    }
}
