using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IWeaponRepository
    {
        Task<Weapon?> GetByIdAsync(Guid id);
    }
}
