namespace redimel_server.Models.Domain
{
    public class Shield
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public Boolean IsExist { get; set; }
        public int Defence { get; set; }
    }
}
