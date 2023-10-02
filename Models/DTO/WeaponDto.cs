using redimel_server.Models.Enums;

namespace redimel_server.Models.DTO
{
    public class WeaponDto
    {
        public Guid Id { get; set; }
        public WeaponType WeaponType { get; set; }
        public Boolean IsExist { get; set; }
        public Boolean IsItTwoHandWeapon { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Damage { get; set; }
        public int WeaponRange { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
