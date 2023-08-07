namespace redimel_server.Models.Domain.RedimelDomain
{
    public class SouthernNomads
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> SouthernNomadsVariables { get; set; }
    }
}
