using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMissionRepository missionRepository;

        public MissionsController(IMapper mapper, IMissionRepository missionRepository)
        {
            this.mapper = mapper;
            this.missionRepository = missionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var missionDomain = await missionRepository.GetAllAsync();

            return Ok(mapper.Map<List<MissionDto>>(missionDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var missionDomain = await missionRepository.GetByIdAsync(id);

            if (missionDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<MissionDto>(missionDomain));
        }
    }
}
