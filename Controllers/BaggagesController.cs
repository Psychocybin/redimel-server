using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create([FromBody] AddBaggageRequestDto addBaggageRequestDto)
        {
            var baggageDomainModel = mapper.Map<Baggage>(addBaggageRequestDto);

            await baggageRepository.CreateAsync(baggageDomainModel);

            var baggageDto = mapper.Map<BaggageDto>(baggageDomainModel);

            return Ok(baggageDto);
        }
    }
}
