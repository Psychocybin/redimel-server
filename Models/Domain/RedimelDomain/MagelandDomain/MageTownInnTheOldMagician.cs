namespace redimel_server.Models.Domain.RedimelDomain.MagelandDomain
{
    public class MageTownInnTheOldMagician
    {
        public Guid Id { get; set; }
        public Guid MageTownId { get; set; }
        public virtual ICollection<WorldInfoVariable> MageTownOldMagicianVariables { get; set; }
    }
}
