namespace redimel_server.Models.Domain
{
    public class Page
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
    }
}
