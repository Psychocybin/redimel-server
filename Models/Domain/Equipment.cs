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
        public Guid ArmorId { get; set; }
        public Guid ShieldId { get; set; }
        public Guid WeaponId { get; set; }
        public Guid ThrowingWeaponId { get; set; }
        public Guid TalismansId { get; set; }
        public ArmorAndShield Armor { get; set; }
        public ArmorAndShield Shield { get; set; }
        public Weapon Weapon { get; set; }
        public ThrowingWeapon ThrowingWeapon { get; set; }
        public ICollection<Talisman> Talismans { get; set; }
    }
}
