using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class UpdatePageRequestDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50000)]
        public string Description { get; set; }
    }
}
