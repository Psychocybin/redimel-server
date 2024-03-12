using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redimel_server.CustomActionFilters;
using redimel_server.Infrastructure;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartGameController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IStartGameRepository startGameRepository;
        private readonly IAuxiliaryRepository auxiliaryRepository;

        public StartGameController(IUserRepository userRepository, IMapper mapper, IStartGameRepository startGameRepository,
            IAuxiliaryRepository auxiliaryRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.startGameRepository = startGameRepository;
            this.auxiliaryRepository = auxiliaryRepository;
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> CreateUserAndGroupWest([FromBody] AddGroupWestHeroesRequestDto addGroupWestHeroesRequestDto)
        {
            var groupWestHeroesDomain = mapper.Map<GroupWestHeroes>(addGroupWestHeroesRequestDto);
            var userEmail = userRepository.GetUserEmail();

            await userRepository.CreateUserAsync(userEmail, groupWestHeroesDomain);

            return Ok("You have successfully registered heroes to the group!");
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Reader,Writer")]
        [Route("BoardBookGame")]
        public async Task<IActionResult> GetNextPage([FromBody] AddChoiceRequestDto addChoiceRequestDto)
        {
            var choiceDomain = mapper.Map<Choice>(addChoiceRequestDto);

            var page = await startGameRepository.GetNextPageAsync(choiceDomain);
            var user = await auxiliaryRepository.GetUserAndGroupWestHeroesAsync();

            if (page == null || user == null)
            {
                return NotFound("Something missing!");
            }

            var groupBattlePoints = new List<BattlePoint>();

            foreach (var hero in user.GroupWest.Heroes)
            {
                var heroBattlePoints = await auxiliaryRepository.ShowBattlePointsAsync(hero.Id)
                    ?? throw new Exception("Battle points missing!");
                groupBattlePoints.Add(heroBattlePoints);
            }

            var pageRes = mapper.Map<PageDto>(page);
            var userRes = mapper.Map<UserDto>(user);
            var battlePointsRes = mapper.Map<List<BattlePointDto>>(groupBattlePoints);

            var response = new UserGroupWestBattlePointsDto
            {
                Page = pageRes,
                User = userRes,
                BattlePoints = battlePointsRes
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> ShowBattlePoints([FromRoute] Guid id)
        {
            var battlePointsDomain = await auxiliaryRepository.ShowBattlePointsAsync(id);

            if (battlePointsDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BattlePointDto>(battlePointsDomain));
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        [Route("StartGame")]
        public async Task<IActionResult> StartGame()
        {
            var page = await startGameRepository.GetCurrentLocation();
            var user = await auxiliaryRepository.GetUserAndGroupWestHeroesAsync();

            if (page == null || user == null)
            {
                return NotFound("Something missing!");
            }

            var groupBattlePoints = new List<BattlePoint>();

            foreach (var hero in user.GroupWest.Heroes)
            {
                var heroBattlePoints = await auxiliaryRepository.ShowBattlePointsAsync(hero.Id) 
                    ?? throw new Exception("Battle points missing!");
                groupBattlePoints.Add(heroBattlePoints);
            }

            var pageRes = mapper.Map<PageDto>(page);
            var userRes = mapper.Map<UserDto>(user);
            var battlePointsRes = mapper.Map<List<BattlePointDto>>(groupBattlePoints);

            var response = new UserGroupWestBattlePointsDto
            {
                Page = pageRes,
                User = userRes,
                BattlePoints = battlePointsRes
            };

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        [Route("RemoveBattleGroup")]
        public async Task<IActionResult> RemoveBattleGroup()
        {
            var userEmail = userRepository.GetUserEmail();

            var result = await userRepository.RemoveBattleGroup(userEmail);

            if (result == null)
            {
                return BadRequest("Something wrong happened!");
            }

            return Ok(result);
        }
    }
}
