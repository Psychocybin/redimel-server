using redimel_server.Models.Domain;

namespace redimel_server.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Checkpoint { get; set; }
        public int TimeCounter { get; set; }
        public string CurrentUserEmail { get; set; }
        public Guid GroupWestId { get; set; }
        public GroupWestDto GroupWest { get; set; }
    }
}
