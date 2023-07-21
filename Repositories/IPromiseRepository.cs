using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IPromiseRepository
    {
        Task<List<Promise>> GetAllAsync();

        Task<Promise?> GetByIdAsync(Guid id);
    }
}
