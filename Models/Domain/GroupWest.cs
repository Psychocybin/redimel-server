namespace redimel_server.Models.Domain
{
    public class GroupWest
    {
        public Guid Id { get; set; }
        public string ActualMission { get; set; }
        public Guid HeroesId { get; set; }
        public Guid AditionalPointsId { get; set; }
        public Guid MissionsId { get; set; }
        public ICollection<Mission> Missions { get; set; }
        public ICollection<Hero> Heroes { get; set; }
        public AditionalPoint AditionalPoints { get; set; }
    }
}
