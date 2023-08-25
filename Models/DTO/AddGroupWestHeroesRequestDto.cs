using System.ComponentModel.DataAnnotations;

namespace redimel_server.Models.DTO
{
    public class AddGroupWestHeroesRequestDto
    {
        [Required]
        public string FirstHero { get; set; }
        [Required]
        public string SecondHero { get; set; }
        [Required]
        public string ThirdHero { get; set; }
        [Required]
        public string FourthHero { get; set; }
        [Required]
        public string FifthHero { get; set; }
    }
}
