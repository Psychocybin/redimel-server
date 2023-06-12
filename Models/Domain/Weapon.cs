namespace redimel_server.Models.Domain
{
    public class Weapon
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
    }
}
