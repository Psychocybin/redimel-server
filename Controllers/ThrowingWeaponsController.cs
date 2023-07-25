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
    [Authorize]
    public class ThrowingWeaponsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IThrowingWeaponRepository throwingWeaponRepository;

        public ThrowingWeaponsController(IMapper mapper, IThrowingWeaponRepository throwingWeaponRepository)
        {
            this.mapper = mapper;
            this.throwingWeaponRepository = throwingWeaponRepository;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var throwingWeaponDomain = await throwingWeaponRepository.GetByIdAsync(id);

            if (throwingWeaponDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ThrowingWeaponDto>(throwingWeaponDomain));
        }
    }
}
