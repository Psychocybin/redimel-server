using redimel_server.Models.Domain.RedimelDomain.MagelandDomain;
using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain.RedimelDomain
{
    public class Redimel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("Mageland")]
        public Guid MagelandId { get; set; }
        [ForeignKey("TheHorsePeople")]
        public Guid TheHorsePeopleId { get; set; }
        [ForeignKey("Dikani")]
        public Guid DikaniId { get; set; }
        [ForeignKey("Tumpridadam")]
        public Guid TumpridadamId { get; set; }
        [ForeignKey("TheOldKingdom")]
        public Guid TheOldKingdomId { get; set; }
        [ForeignKey("TheHigherOnes")]
        public Guid TheHigherOnesId { get; set; }
        [ForeignKey("TheTradeLeague")]
        public Guid TheTradeLeagueId { get; set; }
        [ForeignKey("Faegra")]
        public Guid FaegraId { get; set; }
        [ForeignKey("TheEmpire")]
        public Guid TheEmpireId { get; set; }
        [ForeignKey("TheBigCity")]
        public Guid TheBigCityId { get; set; }
        [ForeignKey("Stincum")]
        public Guid StincumId { get; set; }
        [ForeignKey("ThePirateDomains")]
        public Guid ThePirateDomainsId { get; set; }
        [ForeignKey("TheIslanders")]
        public Guid TheIslandersId { get; set; }
        [ForeignKey("TheForestTribes")]
        public Guid TheForestTribesId { get; set; }
        [ForeignKey("SouthernNomads")]
        public Guid SouthernNomadsId { get; set; }
        [ForeignKey("NorthernNomads")]
        public Guid NorthernNomadsId { get; set; }
        [ForeignKey("TheHunters")]
        public Guid TheHuntersId { get; set; }
        [ForeignKey("OutlawTerritory")]
        public Guid OutlawTerritoryId { get; set; }
        [ForeignKey("TheWasteland")]
        public Guid TheWastelandId { get; set; }
        [ForeignKey("TheShadowWorld")]
        public Guid TheShadowWorldId { get; set; }
        public virtual TheHorsePeople TheHorsePeople { get; set; }
        public virtual Dikani Dikani { get; set; }
        public virtual Mageland Magelands { get; set; }
        public virtual Tumpridadam Tumpridadam { get; set; }
        public virtual TheOldKingdom TheOldKingdom { get; set; }
        public virtual TheHigherOnes TheHigherOnes { get; set; }
        public virtual TheTradeLeague TheTradeLeague { get; set; }
        public virtual Faegra Faegra { get; set; }
        public virtual TheEmpire TheEmpire { get; set; }
        public virtual TheBigCity TheBigCity { get; set; }
        public virtual Stincum Stincum { get; set; }
        public virtual ThePirateDomains ThePirateDomains { get; set; }
        public virtual TheIslanders TheIslanders { get; set; }
        public virtual TheForestTribes TheForestTribes { get; set; }
        public virtual SouthernNomads SouthernNomads { get; set; }
        public virtual NorthernNomads NorthernNomads { get; set; }
        public virtual TheHunters TheHunters { get; set; }
        public virtual OutlawTerritory OutlawTerritory { get; set; }
        public virtual TheWasteland TheWasteland { get; set; }
        public virtual TheShadowWorld TheShadowWorld { get; set; }
        public virtual ICollection<WorldInfoVariable> RedimelVariables { get; set; }
    }
}
