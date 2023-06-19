using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IIndicatorRepository
    {
        Task<List<Indicator>> GetAllAsync();

        Task<Indicator?> GetByIdAsync(Guid id);

        Task<Indicator> CreateAsync(Indicator indicator);

        Task<Indicator?> UpdateAsync(Guid id, Indicator indicator);

        Task<Indicator?> DeleteAsync(Guid id);
    }
}
