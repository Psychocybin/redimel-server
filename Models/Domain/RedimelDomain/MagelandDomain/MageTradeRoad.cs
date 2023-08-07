namespace redimel_server.Models.Domain.RedimelDomain.MagelandDomain
{
    public class MageTradeRoad
    {
        public Guid Id { get; set; }
        public Guid MagelandId { get; set; }
        public virtual ICollection<WorldInfoVariable> MageTradeRoadVariables { get; set; }
    }
}
