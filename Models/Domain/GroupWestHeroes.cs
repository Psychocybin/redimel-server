using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    [NotMapped]
    public class GroupWestHeroes
    {
        public string FirstHero { get; set; }
        public string SecondHero { get; set; }
        public string ThirdHero { get; set; }
        public string FourthHero { get; set; }
    }
}
