using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class AddRedimelInfoRequestDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MinLength(15)]
        [MaxLength(10000)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string? AdditionalInfo { get; set; }
    }
}
