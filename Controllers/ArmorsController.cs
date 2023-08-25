using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmorsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IArmorRepository armorRepository;

        public ArmorsController(IMapper mapper, IArmorRepository armorRepository)
        {
            this.mapper = mapper;
            this.armorRepository = armorRepository;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var armorDomain = await armorRepository.GetByIdAsync(id);

            if (armorDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ArmorDto>(armorDomain));
        }
    }
}
