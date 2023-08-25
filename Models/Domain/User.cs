using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? CurrentLocation { get; set; }
        public string? Checkpoint { get; set; }
        public int TimeCounter { get; set; }
        public string CurrentUserEmail { get; set; }
        [ForeignKey("GroupWest")]
        public Guid GroupWestId { get; set; }
        public virtual GroupWest GroupWest { get; set; }
        public virtual ICollection<WorldInfoVariable> WorldInfoVariables { get; set; }
    }
}
