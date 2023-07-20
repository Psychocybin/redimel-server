using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IArmorRepository
    {
        Task<Armor?> GetByIdAsync(Guid id);
    }
}
