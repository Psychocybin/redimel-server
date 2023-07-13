namespace redimel_server.Models.DTO
{
    public class AddBaggageRequestDto
    {
        public string Name { get; set; }
        public double Volume { get; set; }
        public Guid HeroId { get; set; }
    }
}
