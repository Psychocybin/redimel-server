using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class Weapon
    {
        public Guid Id { get; set; }
        public string WeaponType { get; set; }
        public Boolean IsExist { get; set; }
        public Boolean IsItTwoHandWeapon { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Damage { get; set; }
        public int WeaponRange { get; set; }
        //[ForeignKey("Equipment")]
        public Guid EquipmentId { get; set; }
        //public Equipment Equipment { get; set; }
    }
}
