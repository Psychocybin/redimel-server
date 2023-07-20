using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IEquipmentRepository
    {
        Task<Equipment?> GetByIdAsync(Guid id);
    }
}
