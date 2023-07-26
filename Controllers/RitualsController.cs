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
    public class RitualsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRitualRepository ritualRepository;

        public RitualsController(IMapper mapper, IRitualRepository ritualRepository)
        {
            this.mapper = mapper;
            this.ritualRepository = ritualRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            var ritualDomain = await ritualRepository.GetAllAsync();

            return Ok(mapper.Map<List<RitualDto>>(ritualDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var ritualDomain = await ritualRepository.GetByIdAsync(id);

            if (ritualDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RitualDto>(ritualDomain));
        }
    }
}
