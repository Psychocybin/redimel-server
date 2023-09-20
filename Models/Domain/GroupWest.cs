using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class GroupWest
    {
        public GroupWest()
        {
            this.Missions = new List<Mission>();
            this.Heroes = new List<Hero>();
        }

        public Guid Id { get; set; }
        public string ActualMission { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("AditionalPoints")]
        public Guid AditionalPointsId { get; set; }
        public virtual AditionalPoint AditionalPoints { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
