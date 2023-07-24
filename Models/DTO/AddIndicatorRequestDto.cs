using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class AddIndicatorRequestDto
    {
        [Required]
        [Range(1, 1000)]
        public int Health { get; set; }

        [Required]
        [Range (0, 1000)]
        public int MentalEnergy { get; set; }

        [Required]
        [Range(1, 100)]
        public int MentalStrength { get; set; }

        [Required]
        [Range(1, 100)]
        public int Strength { get; set; }

        [Required]
        [Range(1, 100)]
        public int Dexterity { get; set; }

        [Required]
        [Range(1, 100)]
        public int Agility { get; set; }

        [Required]
        [Range(1, 100)]
        public int Evasion { get; set; }

        [Required]
        [Range(1, 100)]
        public int Endurance { get; set; }

        [Required]
        public Guid HeroId { get; set; }
    }
}
