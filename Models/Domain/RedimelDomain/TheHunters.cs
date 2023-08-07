namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheHunters
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheHuntersVariables { get; set; }
    }
}
