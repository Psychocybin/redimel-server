using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    [NotMapped]
    public class GroupWestHeroes
    {
        public string Warrior { get; set; }
        public string Fighter { get; set; }
        public string Defender { get; set; }
        public string Helper { get; set; }
        public string Mystic { get; set; }
    }
}
