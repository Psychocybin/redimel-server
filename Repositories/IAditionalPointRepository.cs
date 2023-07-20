using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IAditionalPointRepository
    {
        Task<AditionalPoint?> GetByIdAsync(Guid id);
    }
}
