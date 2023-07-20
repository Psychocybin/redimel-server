namespace redimel_server.Models.DTO
{
    public class BattleGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CountPeople { get; set; }
        public Guid AditionalPointsId { get; set; }
    }
}
