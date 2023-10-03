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

            var nextPage = await startGameRepository.GetNextPageAsync(choiceDomain);

            var nextPageDto = mapper.Map<PageDto>(nextPage);
            return Ok(nextPageDto);
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
    }
}
