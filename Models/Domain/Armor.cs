namespace redimel_server.Models.Domain
{
    public class Armor
    {
        public Guid Id { get; set; }
        public string ArmorType { get; set; }
        public Boolean IsExist { get; set; }
        public int Defence { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
