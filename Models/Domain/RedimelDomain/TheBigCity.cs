namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheBigCity
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheBigCityVariables { get; set; }
    }
}
