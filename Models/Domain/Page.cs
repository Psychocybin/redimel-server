namespace redimel_server.Models.Domain
{
    public class Page
    {
        public Page()
        {
            this.Choices = new List<Choice>();
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
    }
}
