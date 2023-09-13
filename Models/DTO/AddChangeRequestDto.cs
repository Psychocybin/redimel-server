using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class AddChangeRequestDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string ClassName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string PropertyName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string ActionType { get; set; }
        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        public string PageId { get; set; }
        [MinLength(2)]
        [MaxLength(50)]
        public string? Name { get; set; }
        [MinLength(2)]
        [MaxLength(50)]
        public string? Description { get; set; }
        [MinLength(2)]
        [MaxLength(50)]
        public string? AdditionalInfo { get; set; }
        public Boolean TrueOrFalse { get; set; }
        public Boolean ActiveOrNot { get; set; }
        [Range(-10000, 10000)]
        public int Attack { get; set; }
        [Range(-10000, 10000)]
        public int Defence { get; set; }
        [Range(-10000, 10000)]
        public int Damage { get; set; }
        [Range(-10000.0, 10000.0)]
        public double Range { get; set; }
        [Range(-10000.0, 10000.0)]
        public double Quantity { get; set; }
    }
}
