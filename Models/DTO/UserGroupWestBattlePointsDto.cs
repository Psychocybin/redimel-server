namespace redimel_server.Models.DTO
{
    public class UserGroupWestBattlePointsDto
    {
        public PageDto Page { get; set; }
        public UserDto User { get; set; }
        public List<BattlePointDto> BattlePoints { get; set; }
    }
}
