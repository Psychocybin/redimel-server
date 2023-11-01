using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class UpdateChoiceRequestDto
    {
        [Required]
        public Boolean AdditionalCheck { get; set; }
        [Required]
        public Boolean IsUniqueChoice { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        public string Description { get; set; }
        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        public string NextPage { get; set; }
        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        public string PageId { get; set; }
    }
}
