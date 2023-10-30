using redimel_server.Models.Domain;

namespace redimel_server.Infrastructure
{
    public class ChangeResponse
    {
        public string ChangeNotice { get; set; }
        public Choice? Choice { get; set; }
    }
}
