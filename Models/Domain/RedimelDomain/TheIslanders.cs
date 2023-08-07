namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheIslanders
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheIslandersVariables { get; set; }
    }
}
