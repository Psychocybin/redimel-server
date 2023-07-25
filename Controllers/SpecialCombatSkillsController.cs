using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SpecialCombatSkillsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISpecialCombatSkillRepository specialCombatSkillRepository;

        public SpecialCombatSkillsController(IMapper mapper, ISpecialCombatSkillRepository specialCombatSkillRepository)
        {
            this.mapper = mapper;
            this.specialCombatSkillRepository = specialCombatSkillRepository;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var scsDomain = await specialCombatSkillRepository.GetByIdAsync(id);

            if (scsDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<SpecialCombatSkillDto>(scsDomain));
        }
    }
}
