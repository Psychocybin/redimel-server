using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IRedimelInfoRepository
    {
        Task<List<RedimelInfo>> GetAllAsync();

        Task<RedimelInfo?> GetByIdAsync(Guid id);

        Task<RedimelInfo> CreateAsync(RedimelInfo redimelInfo);

        Task<RedimelInfo?> UpdateAsync(Guid id, RedimelInfo redimelInfo);

        Task<RedimelInfo?> DeleteAsync(Guid id);
    }
}
