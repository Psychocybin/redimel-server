using redimel_server.Infrastructure;

namespace redimel_server.Repositories
{
    public interface IAuxiliaryRepository
    {
        Task<BattlePoint?> ShowBattlePointsAsync(Guid id);
    }
}
