using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IRitualRepository
    {
        Task<List<Ritual>> GetAllAsync();

        Task<Ritual?> GetByIdAsync(Guid id);

    }
}
