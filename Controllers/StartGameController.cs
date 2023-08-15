using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redimel_server.CustomActionFilters;
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

        public StartGameController(IUserRepository userRepository, IMapper mapper, IStartGameRepository startGameRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.startGameRepository = startGameRepository;
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> CreateGroupWestHeroes([FromBody] AddGroupWestHeroesRequestDto addGroupWestHeroesRequestDto)
        {
            var groupWestHeroesDomain = mapper.Map<GroupWestHeroes>(addGroupWestHeroesRequestDto);
            var userEmail = userRepository.GetUserEmail();

            await userRepository.CreateUserAsync(userEmail, groupWestHeroesDomain);

            return Ok("You have successfully registered heroes to the group!");
        }

        [HttpPost]
        [Authorize(Roles = "Reader,Writer")]
        [Route("BoardBookGame")]
        public async Task<IActionResult> GetNextPage([FromBody] ChoiceDto choiceDto)
        {
            var choiceDomain = mapper.Map<Choice>(choiceDto);

            var nextPage = await startGameRepository.GetNextPage(choiceDomain);

            var nextPageDto = mapper.Map<PageDto>(nextPage);
            return Ok(nextPageDto);
        }
    }
}
