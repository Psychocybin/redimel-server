using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalismansController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITalismanRepository talismanRepository;

        public TalismansController(IMapper mapper, ITalismanRepository talismanRepository)
        {
            this.mapper = mapper;
            this.talismanRepository = talismanRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            var talismanDomain = await talismanRepository.GetAllAsync();

            return Ok(mapper.Map<List<TalismanDto>>(talismanDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var talismanDomain = await talismanRepository.GetByIdAsync(id);

            if (talismanDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TalismanDto>(talismanDomain));
        }
    }
}
