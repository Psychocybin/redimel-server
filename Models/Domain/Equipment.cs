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
        public Guid ArmorsId { get; set; }
        public Guid ShieldsId { get; set; }
        public Guid WeaponsId { get; set; }
        public Guid ThrowingWeaponsId { get; set; }
        public Guid TalismansId { get; set; }
        public Armor Armors { get; set; }
        public Shield Shields { get; set; }
        public Weapon Weapons { get; set; }
        public ThrowingWeapon ThrowingWeapons { get; set; }
        public ICollection<Talisman> Talismans { get; set; }
    }
}
