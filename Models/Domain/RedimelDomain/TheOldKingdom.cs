namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheOldKingdom
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheOldKingdomVariables { get; set; }
    }
}
