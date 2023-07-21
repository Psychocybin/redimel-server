using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IHeroRepository
    {
        Task<Hero?> GetByIdAsync(Guid id);
    }
}
