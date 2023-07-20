using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IBaggageRepository
    {
        Task<Baggage> CreateAsync(Baggage baggage);

        Task<List<Baggage>> GetAllAsync();

        Task<Baggage?> GetByIdAsync(Guid id);

        Task<Baggage?> DeleteAsync(Guid id);
    }
}
