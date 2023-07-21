namespace redimel_server.Models.DTO
{
    public class MissionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Boolean IsItDone { get; set; }
        public Guid GroupWestId { get; set; }
    }
}
