using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleGroupsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBattleGroupRepository battleGroupRepository;

        public BattleGroupsController(IMapper mapper, IBattleGroupRepository battleGroupRepository)
        {
            this.mapper = mapper;
            this.battleGroupRepository = battleGroupRepository;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var battleGroupDomain = await battleGroupRepository.GetByIdAsync(id);

            if (battleGroupDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BattleGroupDto>(battleGroupDomain));
        }
    }
}
