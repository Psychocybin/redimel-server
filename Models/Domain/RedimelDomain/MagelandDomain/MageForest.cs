namespace redimel_server.Models.Domain.RedimelDomain.MagelandDomain
{
    public class MageForest
    {
        public Guid Id { get; set; }
        public Guid MagelandId { get; set; }
        public virtual ICollection<WorldInfoVariable> MageForestVariables { get; set; }
    }
}
