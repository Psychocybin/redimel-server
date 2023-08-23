using redimel_server.Models.Domain;

namespace redimel_server.Models.DTO
{
    public class PageDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public List<ChoiceDto> Choices { get; set; }
    }
}
