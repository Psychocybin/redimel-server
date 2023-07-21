namespace redimel_server.Models.DTO
{
    public class TalismanDto
    {
        public Guid Id { get; set; }
        public string TalismanType { get; set; }
        public string Name { get; set; }
        public string BonusIndicator { get; set; }
        public int BonusPoints { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
