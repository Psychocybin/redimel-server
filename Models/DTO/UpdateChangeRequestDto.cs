﻿using redimel_server.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class UpdateChangeRequestDto
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
        public ActionType ActionType { get; set; }
        public HeroClass HeroClass { get; set; }
        public HeroType HeroType { get; set; }
        public OrderOfBattle OrderOfBattle { get; set; }
        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        public string PageId { get; set; }
        [Required]
        public Guid ChoiceId { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Description { get; set; }
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
