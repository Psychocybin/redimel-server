using redimel_server.Models.Domain;

namespace redimel_server.Models.DTO
{
    public class EquipmentDto
    {
        public Guid Id { get; set; }
        public Boolean Knife { get; set; }
        public Boolean SmokeBall { get; set; }
        public Boolean Poison { get; set; }
        public Boolean MedicPack { get; set; }
        public int MoneyBag { get; set; }
        public Guid HeroId { get; set; }
        public Guid ArmorId { get; set; }
        public Guid ShieldId { get; set; }
        public Guid WeaponId { get; set; }
        public Guid ThrowingWeaponId { get; set; }
        public ArmorDto Armor { get; set; }
        public ShieldDto Shield { get; set; }
        public WeaponDto Weapon { get; set; }
        public ThrowingWeaponDto ThrowingWeapon { get; set; }
        public List<TalismanDto> Talismans { get; set; }
    }
}
