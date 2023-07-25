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
    public class ShieldsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IShieldRepository shieldRepository;

        public ShieldsController(IMapper mapper, IShieldRepository shieldRepository)
        {
            this.mapper = mapper;
            this.shieldRepository = shieldRepository;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var shieldDomain = await shieldRepository.GetByIdAsync(id);

            if (shieldDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ShieldDto>(shieldDomain));
        }
    }
}
