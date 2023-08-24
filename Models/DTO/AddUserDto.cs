using redimel_server.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.DTO
{
    public class AddUserDto
    {
        public Guid Id { get; set; }
        public string? CurrentLocation { get; set; }
        public string? Checkpoint { get; set; }
        public int TimeCounter { get; set; }
        public Guid CurrentUserId { get; set; }
        public Guid RedimelId { get; set; }
        public Guid GroupWestId { get; set; }
        public virtual GroupWest GroupWest { get; set; }
    }
}
