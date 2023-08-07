namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheShadowWorld
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheShadowWorldVariables { get; set; }
    }
}
