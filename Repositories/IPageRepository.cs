using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IPageRepository
    {
        Task<List<Page>> GetAllAsync();
        Task<Page?> GetByIdAsync(string id);
        Task<Page> CreateAsync(Page page);
        Task<Page?> UpdateAsync(string id, Page page);
        Task<Page?> DeleteAsync(string id);
    }
}
