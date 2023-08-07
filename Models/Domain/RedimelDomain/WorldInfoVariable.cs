namespace redimel_server.Models.Domain.RedimelDomain
{
    public class WorldInfoVariable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
        public Boolean TrueOrFalse { get; set; }
    }
}
