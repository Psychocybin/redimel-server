using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IIndicatorRepository
    {
        Task<List<Indicator>> GetAllAsync();
    }
}
