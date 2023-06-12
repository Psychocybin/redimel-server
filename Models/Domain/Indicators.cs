namespace redimel_server.Models.Domain
{
    public class Indicators
    {
        public Guid Id { get; set; }
        public int Health { get; set; }
        public int MentalEnergy { get; set; }
        public int MentalStrength { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Evasion { get; set; }
        public int Endurance { get; set; }
    }
}
