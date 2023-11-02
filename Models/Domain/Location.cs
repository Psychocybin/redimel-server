using redimel_server.Utils;

namespace redimel_server.Models.Domain
{
    public class Location
    {
        public Location()
        {
            this.PageId = RedimelConstants.STARTLOCATION;
        }

        public Guid Id { get; set; }
        public string PageId { get; set; }
        public string ChangeNotice { get; set; }
        public string ChoicesId { get; set; }
        public string ImagesId { get; set; }
        public Guid UserId { get; set; }
    }
}
