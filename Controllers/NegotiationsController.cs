using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegotiationsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly INegotiationRepository negotiationRepository;

        public NegotiationsController(IMapper mapper, INegotiationRepository negotiationRepository)
        {
            this.mapper = mapper;
            this.negotiationRepository = negotiationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var negotiationDomain = await negotiationRepository.GetAllAsync();

            return Ok(mapper.Map<List<NegotiationDto>>(negotiationDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var negotiationDomain = await negotiationRepository.GetByIdAsync(id);

            if (negotiationDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<NegotiationDto>(negotiationDomain));
        }
    }
}
