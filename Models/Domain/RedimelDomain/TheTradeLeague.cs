namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheTradeLeague
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheTradeLeagueVariables { get; set; }
    }
}
