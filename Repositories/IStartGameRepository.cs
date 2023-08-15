using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IStartGameRepository
    {
        Task<Page> GetNextPage(Choice choice);
    }
}
