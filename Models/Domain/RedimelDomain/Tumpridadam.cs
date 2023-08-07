namespace redimel_server.Models.Domain.RedimelDomain
{
    public class Tumpridadam
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TumpridadamVariables { get; set; }
    }
}
