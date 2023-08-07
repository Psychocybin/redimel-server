using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain.RedimelDomain.MagelandDomain
{
    public class MageTownTheLibrary
    {
        public Guid Id { get; set; }
        public Guid MageTownId { get; set; }
        public virtual ICollection<WorldInfoVariable> MageTownTheLibraryVariables { get; set; }
    }
}
