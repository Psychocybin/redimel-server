using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain.RedimelDomain.MagelandDomain
{
    public class Mageland
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        [ForeignKey("MageTown")]
        public Guid MageTownId { get; set; }
        [ForeignKey("MageFields")]
        public Guid MageFieldsId { get; set; }
        [ForeignKey("MageForest")]
        public Guid MageForestId { get; set; }
        [ForeignKey("MageSea")]
        public Guid MageSeaId { get; set; }
        [ForeignKey("MageHarbor")]
        public Guid MageHarborId { get; set; }
        [ForeignKey("MageTradeRoad")]
        public Guid MageTradeRoadId { get; set; }
        public virtual MageTown MageTown { get; set; }
        public virtual MageTradeRoad MageTradeRoad { get; set; }
        public virtual MageSea MageSea { get; set; }
        public virtual MageHarbor MageHarbor { get; set; }
        public virtual MageForest MageForest { get; set; }
        public virtual MageFields MageFields { get; set; }
        public virtual ICollection<WorldInfoVariable> MagelandVariables { get; set; }
    }
}
