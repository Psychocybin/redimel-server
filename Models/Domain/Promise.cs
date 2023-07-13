namespace redimel_server.Models.Domain
{
    public class Promise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Boolean IsItDone { get; set; }
        public Guid HeroId { get; set; }
        public virtual Hero Hero { get; set; }
    }
}
