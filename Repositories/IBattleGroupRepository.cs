using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IBattleGroupRepository
    {
        Task<BattleGroup?> GetByIdAsync(Guid id);
    }
}
