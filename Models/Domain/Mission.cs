namespace redimel_server.Models.Domain
{
    public class Mission
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Boolean IsItDone { get; set; }
        public Guid GroupWestId { get; set; }
        public GroupWest GroupWest { get; set; }
    }
}
