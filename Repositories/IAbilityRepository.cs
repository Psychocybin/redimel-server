using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IAbilityRepository
    {
        Task<List<Ability>> GetAllAsync();

        Task<Ability?> GetByIdAsync(Guid id);
    }
}
