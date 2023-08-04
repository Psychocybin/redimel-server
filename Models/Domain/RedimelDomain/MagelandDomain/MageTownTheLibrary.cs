using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain.RedimelDomain.MagelandDomain
{
    public class MageTownTheLibrary
    {
        public Guid Id { get; set; }
        public int BooksRead { get; set; }
        public string? AnAlly { get; set; }
        public Boolean ShadowHunter { get; set; }
        public Boolean SeekerOfTheLight { get; set; }
        public Boolean IsTheGuardAlive { get; set; }
        public Guid MageTownId { get; set; }
    }
}
