using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redimel_server.CustomActionFilters;
using redimel_server.Models.DTO;
using redimel_server.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using redimel_server.Models.Domain;
using AutoMapper;

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

        // UserManager<User> userManager

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        //[Route("Users/current")]
        public async Task<IActionResult> GetUserId()
        {
            //var newUser = new User
            //{
            //    CurrentUserId = userRepository.GetUserId().ToString()
            //};
            //var userId = userRepository.GetUserId();
            //var userId = HttpContext.User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/Id");
            //var userId = HttpContext.User.Identity.Name;
            //var userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userId = HttpContext.User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier/Id");
            //var userId = newUser.CurrentUserId;
            //var userId = HttpContext.User.FindFirstValue("Id");

            var userId = userRepository.GetUserId();

            return Ok(userId);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> CreateOwnBattleGroup([FromBody] AddHeroDto hero)
        {
            //TO DO
            
            var userId = userRepository.GetUserId();

            return Ok(userId);
        }

        [HttpPost]
        [Authorize(Roles = "Reader,Writer")]
        [Route("BoardBookGame")]
        public async Task<IActionResult> GetNextPage([FromBody] ChoiceDto choiceDto)
        {
            var choiceDomain = mapper.Map<Choice>(choiceDto);

            var nextPage = startGameRepository.GetNextPage(choiceDomain);

            var nextPageDto = mapper.Map<PageDto>(nextPage);
            return Ok(nextPageDto);
        }
    }
}
