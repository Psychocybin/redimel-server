namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheWasteland
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheWastelandVariables { get; set; }
    }
}
