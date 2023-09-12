using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class AddGroupWestHeroesRequestDto
    {
        [Required]
        public string Warrior { get; set; }
        [Required]
        public string Fighter { get; set; }
        [Required]
        public string Defender { get; set; }
        [Required]
        public string Helper { get; set; }
        [Required]
        public string Mystic { get; set; }
    }
}
