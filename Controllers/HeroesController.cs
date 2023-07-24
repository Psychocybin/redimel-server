using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IHeroRepository heroRepository;

        public HeroesController(IMapper mapper, IHeroRepository heroRepository)
        {
            this.mapper = mapper;
            this.heroRepository = heroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var heroDomain = await heroRepository.GetAllAsync();

            return Ok(mapper.Map<List<HeroDto>>(heroDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var heroDomain = await heroRepository.GetByIdAsync(id);

            if (heroDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<HeroDto>(heroDomain));
        }
    }
}
