namespace redimel_server.Models.DTO
{
    public class RedimelInfoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
