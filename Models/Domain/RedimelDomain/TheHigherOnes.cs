namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheHigherOnes
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheHigherOnesVariables { get; set; }
    }
}
