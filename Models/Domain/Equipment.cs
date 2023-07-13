using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public Boolean Knife { get; set; }
        public Boolean SmokeBall { get; set; }
        public Boolean Poison { get; set; }
        public Boolean MedicPack { get; set; }
        public int MoneyBag { get; set; }
        //[ForeignKey("Hero")]
        public Guid HeroId { get; set; }
        [ForeignKey("Armor")]
        public Guid ArmorId { get; set; }
        [ForeignKey("Shield")]
        public Guid ShieldId { get; set; }
        [ForeignKey("Weapon")]
        public Guid WeaponId { get; set; }
        [ForeignKey("ThrowingWeapon")]
        public Guid ThrowingWeaponId { get; set; }
        //public Hero Hero { get; set; }
        public Armor Armor { get; set; }
        public Shield Shield { get; set; }
        public Weapon Weapon { get; set; }
        public ThrowingWeapon ThrowingWeapon { get; set; }
        public ICollection<Talisman> Talismans { get; set; }
    }
}
