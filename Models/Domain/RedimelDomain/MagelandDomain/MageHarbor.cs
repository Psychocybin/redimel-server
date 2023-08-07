namespace redimel_server.Models.Domain.RedimelDomain.MagelandDomain
{
    public class MageHarbor
    {
        public Guid Id { get; set; }
        public Guid MagelandId { get; set; }
        public virtual ICollection<WorldInfoVariable> MageHarborVariables { get; set; }
    }
}
