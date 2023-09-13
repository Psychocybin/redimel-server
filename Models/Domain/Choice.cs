namespace redimel_server.Models.Domain
{
    public class Choice
    {
        public Guid Id { get; set; }
        public Boolean AdditionalCheck { get; set; }
        public string Description { get; set; }
        public string NextPage { get; set; }
        public string PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}
