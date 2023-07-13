namespace redimel_server.Models.Domain
{
    public class Talisman
    {
        public Guid Id { get; set; }
        public string TalismanType { get; set; }
        public string Name { get; set; }
        public string BonusIndicator { get; set; }
        public int BonusPoints { get; set; }
        public Guid EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
