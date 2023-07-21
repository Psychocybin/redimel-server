using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IUltimateRepository
    {
        Task<Ultimate?> GetByIdAsync(Guid id);
    }
}
