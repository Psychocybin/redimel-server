namespace redimel_server.Models.Domain.RedimelDomain
{
    public class OutlawTerritory
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> OutlawTerritoryVariables { get; set; }
    }
}
