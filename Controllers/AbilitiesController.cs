using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAbilityRepository abilityRepository;

        public AbilitiesController(IMapper mapper, IAbilityRepository abilityRepository)
        {
            this.mapper = mapper;
            this.abilityRepository = abilityRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetAll()
        {
            var abilityDomain = await abilityRepository.GetAllAsync();

            var abilityDto = mapper.Map<List<AbilityDto>>(abilityDomain);

            return Ok(abilityDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var abilityDomain = await abilityRepository.GetByIdAsync(id);

            if (abilityDomain == null)
            {
                return NotFound();
            }

            var abilityDto = mapper.Map<AbilityDto>(abilityDomain);

            return Ok(abilityDto);
        }
    }
}
