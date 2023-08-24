using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class WorldInfoVariable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RedimelLocation { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
        public bool ActiveOrNot { get; set; }
        public bool TrueOrFalse { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }

    }
}
