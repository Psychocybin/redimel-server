using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class Equipment
    {
        public Equipment()
        {
            this.Talismans = new List<Talisman>();
        }

        public Guid Id { get; set; }
        public Boolean Knife { get; set; }
        public Boolean SmokeBall { get; set; }
        public Boolean Poison { get; set; }
        public Boolean MedicPack { get; set; }
        public int MoneyBag { get; set; }
        public Guid HeroId { get; set; }
        [ForeignKey("Armor")]
        public Guid ArmorId { get; set; }
        [ForeignKey("Shield")]
        public Guid ShieldId { get; set; }
        [ForeignKey("Weapon")]
        public Guid WeaponId { get; set; }
        [ForeignKey("ThrowingWeapon")]
        public Guid ThrowingWeaponId { get; set; }
        public virtual Armor Armor { get; set; }
        public virtual Shield Shield { get; set; }
        public virtual Weapon Weapon { get; set; }
        public virtual ThrowingWeapon ThrowingWeapon { get; set; }
        public virtual ICollection<Talisman> Talismans { get; set; }
    }
}
