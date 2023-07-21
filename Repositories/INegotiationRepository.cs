using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface INegotiationRepository
    {
        Task<List<Negotiation>> GetAllAsync();

        Task<Negotiation?> GetByIdAsync(Guid id);
    }
}
