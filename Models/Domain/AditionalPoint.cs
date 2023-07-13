using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class AditionalPoint
    {
        public Guid Id { get; set; }
        public int TeamGame { get; set; }
        public int ImportantInformation { get; set; }
        public int SlainMonsters { get; set; }
        public int Morals { get; set; }
        public int Cover { get; set; }
        //[ForeignKey("GroupWest")]
        public Guid GroupWestId { get; set; }
        //public GroupWest GroupWest { get; set; }
        public ICollection<BattleGroup> BattleGroups { get; set; }
        public ICollection<Negotiation> Negotiations { get; set; }
    }
}
