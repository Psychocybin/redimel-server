namespace redimel_server.Models.Domain
{
    public class RedimelInfo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
