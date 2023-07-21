using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface ITalismanRepository
    {
        Task<List<Talisman>> GetAllAsync();

        Task<Talisman?> GetByIdAsync(Guid id);
    }
}
