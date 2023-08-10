using Microsoft.AspNetCore.Identity;
using redimel_server.Models.Domain.RedimelDomain;
using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? CurrentLocation { get; set; }
        public string? Checkpoint { get; set; }
        public int TimeCounter { get; set; }
        public string? CurrentUserId { get; set; }
        [ForeignKey("Redimel")]
        public Guid? RedimelId { get; set; }
        [ForeignKey("GroupWest")]
        public Guid? GroupWestId { get; set; }
        public virtual Redimel? Redimel { get; set; }
        public virtual GroupWest? GroupWest { get; set; }
    }
}
