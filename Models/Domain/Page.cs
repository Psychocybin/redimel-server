namespace redimel_server.Models.Domain
{
    public class Page
    {
        public Page()
        {
            this.Choices = new List<Choice>();
            this.Images = new List<Image>();
            this.ChangeNotices = "";
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public string ChangeNotices { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
