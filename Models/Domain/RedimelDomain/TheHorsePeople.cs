namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheHorsePeople
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheHorsePeopleVariables { get; set; }
    }
}
