namespace redimel_server.Models.Domain
{
    public class BattleGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CountPeople { get; set; }
        public Guid AditionalPointsId { get; set; }
        public AditionalPoint AditionalPoints { get; set; }
    }
}
