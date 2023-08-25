using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class AddPageRequestDto
    {
        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        public string Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50000)]
        public string Description { get; set; }
    }
}
