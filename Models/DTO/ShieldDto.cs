namespace redimel_server.Models.DTO
{
    public class ShieldDto
    {
        public Guid Id { get; set; }
        public string ShieldType { get; set; }
        public Boolean IsExist { get; set; }
        public int Defence { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
