using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IMissionRepository
    {
        Task<List<Mission>> GetAllAsync();

        Task<Mission?> GetByIdAsync(Guid id);
    }
}
