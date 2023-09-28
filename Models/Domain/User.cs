using redimel_server.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class User
    {
        public User()
        {
            this.CurrentLocation = RedimelConstants.STARTLOCATION;
            this.Checkpoint = RedimelConstants.STARTLOCATION;
            this.TimeCounter = 1;
            this.WorldInfoVariables = new List<WorldInfoVariable>();
        }

        public Guid Id { get; set; }
        public string CurrentLocation { get; set; }
        public string Checkpoint { get; set; }
        public int TimeCounter { get; set; }
        public string CurrentUserEmail { get; set; }
        [ForeignKey("GroupWest")]
        public Guid GroupWestId { get; set; }
        public virtual GroupWest GroupWest { get; set; }
        public virtual ICollection<WorldInfoVariable> WorldInfoVariables { get; set; }
    }
}
