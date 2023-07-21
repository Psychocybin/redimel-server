using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IThrowingWeaponRepository
    {
        Task<ThrowingWeapon?> GetByIdAsync(Guid id);
    }
}
