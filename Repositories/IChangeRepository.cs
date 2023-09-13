using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IChangeRepository
    {
        Task<List<Change>> GetAllAsync();

        Task<Change?> GetByIdAsync(Guid id);

        Task<Change> CreateAsync(Change change);

        Task<Change?> UpdateAsync(Guid id, Change change);

        Task<Change?> DeleteAsync(Guid id);
    }
}
