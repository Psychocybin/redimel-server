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
    public class RedimelInfosController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRedimelInfoRepository redimelInfoRepository;

        public RedimelInfosController(IMapper mapper, IRedimelInfoRepository redimelInfoRepository)
        {
            this.mapper = mapper;
            this.redimelInfoRepository = redimelInfoRepository;
        }

        [HttpGet]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetAll()
        {
            var redimelInfoDomain = await redimelInfoRepository.GetAllAsync();

            return Ok(mapper.Map<List<RedimelInfoDto>>(redimelInfoDomain));
        }

        [HttpGet]
        //[Authorize(Roles = "Reader,Writer")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var redimelInfoDomain = await redimelInfoRepository.GetByIdAsync(id);

            if (redimelInfoDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RedimelInfoDto>(redimelInfoDomain));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRedimelInfoRequestDto addRedimelInfoRequestDto)
        {
            var redimelInfoDomain = mapper.Map<RedimelInfo>(addRedimelInfoRequestDto);

            redimelInfoDomain = await redimelInfoRepository.CreateAsync(redimelInfoDomain);

            var redimelInfoDto = mapper.Map<RedimelInfoDto>(redimelInfoDomain);

            return CreatedAtAction(nameof(GetById), new { id = redimelInfoDto.Id }, redimelInfoDto);
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRedimelInfoRequestDto updateRedimelInfoRequestDto)
        {
            var redimelInfoDomain = mapper.Map<RedimelInfo>(updateRedimelInfoRequestDto);

            redimelInfoDomain = await redimelInfoRepository.UpdateAsync(id, redimelInfoDomain);

            if (redimelInfoDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RedimelInfoDto>(redimelInfoDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var redimelInfoDomain = await redimelInfoRepository.DeleteAsync(id);

            if (redimelInfoDomain == null)
            {
                return NotFound();
            }

            return Ok(redimelInfoDomain);
        }
    }
}
