using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface ISpellRepository
    {
        Task<List<Spell>> GetAllAsync();

        Task<Spell?> GetByIdAsync(Guid id);
    }
}
