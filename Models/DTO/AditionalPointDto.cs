using redimel_server.Models.Domain;

namespace redimel_server.Models.DTO
{
    public class AditionalPointDto
    {
        public Guid Id { get; set; }
        public int TeamGame { get; set; }
        public int ImportantInformation { get; set; }
        public int SlainMonsters { get; set; }
        public int Morals { get; set; }
        public int Cover { get; set; }
        public int TemporaryPoints { get; set; }
        public Guid GroupWestId { get; set; }
        public List<BattleGroupDto> BattleGroups { get; set; }
        public List<NegotiationDto> Negotiations { get; set; }
    }
}
