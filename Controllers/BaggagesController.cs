using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redimel_server.CustomActionFilters;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaggagesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBaggageRepository baggageRepository;

        public BaggagesController(IMapper mapper, IBaggageRepository baggageRepository)
        {
            this.mapper = mapper;
            this.baggageRepository = baggageRepository;
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddBaggageRequestDto addBaggageRequestDto)
        {
            var baggageDomainModel = mapper.Map<Baggage>(addBaggageRequestDto);

            await baggageRepository.CreateAsync(baggageDomainModel);

            var baggageDto = mapper.Map<BaggageDto>(baggageDomainModel);

            return Ok(baggageDto);
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            //var user = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var baggageDomain = await baggageRepository.GetAllAsync();

            return Ok(mapper.Map<List<BaggageDto>>(baggageDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var baggageDomain = await baggageRepository.GetByIdAsync(id);

            if (baggageDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BaggageDto>(baggageDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var baggageDomain = await baggageRepository.DeleteAsync(id);

            if (baggageDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BaggageDto>(baggageDomain));
        }
    }
}
