using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IChoiceRepository
    {
        Task<List<Choice>> GetAllAsync();
        Task<List<Choice>> GetAllForCurrentPageByIdAsync(string id);
        Task<Choice?> GetByIdAsync(Guid id);
        Task<Choice> CreateAsync(Choice choice);
        Task<Choice?> UpdateAsync(Guid id, Choice choice);
        Task<Choice?> DeleteAsync(Guid id);
    }
}
