using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class AddBaggageRequestDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0.1, 100.0)]
        public double Volume { get; set; }

        [Required]
        public Guid HeroId { get; set; }
    }
}
