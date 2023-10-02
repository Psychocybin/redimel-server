using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    [NotMapped]
    public class BooleanPropertyToCheck
    {
        public Boolean ResearchedValue { get; set; }
        public Choice? Choice { get; set; }
    }
}
