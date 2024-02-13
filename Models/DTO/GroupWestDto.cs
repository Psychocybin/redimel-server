using redimel_server.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.DTO
{
    public class GroupWestDto
    {
        public Guid Id { get; set; }
        public string ActualMission { get; set; }
        public Guid UserId { get; set; }
        public Guid AditionalPointsId { get; set; }
        public AditionalPointDto AditionalPoints { get; set; }
        public List<MissionDto> Missions { get; set; }
        public List<HeroDto> Heroes { get; set; }
    }
}
