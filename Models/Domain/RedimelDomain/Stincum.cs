namespace redimel_server.Models.Domain.RedimelDomain
{
    public class Stincum
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> StincumVariables { get; set; }
    }
}
