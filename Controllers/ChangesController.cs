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
    public class ChangesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IChangeRepository changeRepository;

        public ChangesController(IMapper mapper, IChangeRepository changeRepository)
        {
            this.mapper = mapper;
            this.changeRepository = changeRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetAll()
        {
            var changeDomain = await changeRepository.GetAllAsync();

            return Ok(mapper.Map<List<ChangeDto>>(changeDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var changeDomain = await changeRepository.GetByIdAsync(id);

            if (changeDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ChangeDto>(changeDomain));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddChangeRequestDto addChangeRequestDto)
        {
            var changeDomain = mapper.Map<Change>(addChangeRequestDto);

            changeDomain = await changeRepository.CreateAsync(changeDomain);

            var changeDto = mapper.Map<ChangeDto>(changeDomain);

            return CreatedAtAction(nameof(GetById), new { id = changeDto.Id }, changeDto);
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateChangeRequestDto updateChangeRequestDto)
        {
            var changeDomain = mapper.Map<Change>(updateChangeRequestDto);

            changeDomain = await changeRepository.UpdateAsync(id, changeDomain);

            if (changeDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ChangeDto>(changeDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var changeDomain = await changeRepository.DeleteAsync(id);

            if (changeDomain == null)
            {
                return NotFound();
            }

            return Ok(changeDomain);
        }
    }
}
