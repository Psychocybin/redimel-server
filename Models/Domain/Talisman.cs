namespace redimel_server.Models.Domain
{
    public class Talisman
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string BonusIndicator { get; set; }
        public int BonusPoints { get; set; }
    }
}
