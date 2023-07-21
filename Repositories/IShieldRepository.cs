using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IShieldRepository
    {
        Task<Shield?> GetByIdAsync(Guid id);
    }
}
