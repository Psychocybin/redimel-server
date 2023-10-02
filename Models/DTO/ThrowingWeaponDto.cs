using redimel_server.Models.Enums;

namespace redimel_server.Models.DTO
{
    public class ThrowingWeaponDto
    {
        public Guid Id { get; set; }
        public ThrowingWeaponType ThrowingWeaponType { get; set; }
        public Boolean IsExist { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Damage { get; set; }
        public int Quantity { get; set; }
        public int ThrowingWeaponRange { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
