using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UltimatesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUltimateRepository ultimateRepository;

        public UltimatesController(IMapper mapper, IUltimateRepository ultimateRepository)
        {
            this.mapper = mapper;
            this.ultimateRepository = ultimateRepository;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var ultimateDomain = await ultimateRepository.GetByIdAsync(id);

            if (ultimateDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UltimateDto>(ultimateDomain));
        }
    }
}
