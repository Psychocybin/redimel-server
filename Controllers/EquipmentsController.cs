using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEquipmentRepository equipmentRepository;

        public EquipmentsController(IMapper mapper, IEquipmentRepository equipmentRepository)
        {
            this.mapper = mapper;
            this.equipmentRepository = equipmentRepository;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var equipmentDomain = await equipmentRepository.GetByIdAsync(id);

            if (equipmentDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<EquipmentDto>(equipmentDomain));
        }
    }
}
