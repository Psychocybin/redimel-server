namespace redimel_server.Models.Domain
{
    public class Baggage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public Guid HeroId { get; set; }
        public Hero Hero { get; set; }
    }
}
