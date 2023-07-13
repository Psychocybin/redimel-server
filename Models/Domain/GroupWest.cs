using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class GroupWest
    {
        public Guid Id { get; set; }
        public string ActualMission { get; set; }
        [ForeignKey("AditionalPoints")]
        public Guid AditionalPointsId { get; set; }
        public virtual AditionalPoint AditionalPoints { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
