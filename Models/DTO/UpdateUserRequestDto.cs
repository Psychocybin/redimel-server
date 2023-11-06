using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class UpdateUserRequestDto
    {
        [MinLength(15)]
        [MaxLength(15)]
        public string? Checkpoint { get; set; }
        [Required]
        public int TimeCounter { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string CurrentUserEmail { get; set; }
        [Required]
        public Guid GroupWestId { get; set; }
    }
}
