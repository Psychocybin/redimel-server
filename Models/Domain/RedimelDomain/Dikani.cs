namespace redimel_server.Models.Domain.RedimelDomain
{
    public class Dikani
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> DikaniVariables { get; set; }
    }
}
