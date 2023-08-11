using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redimel_server.CustomActionFilters;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoicesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IChoiceRepository choiceRepository;

        public ChoicesController(IMapper mapper, IChoiceRepository choiceRepository)
        {
            this.mapper = mapper;
            this.choiceRepository = choiceRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetAll()
        {
            var choiceDomain = await choiceRepository.GetAllAsync();

            var choiceDto = mapper.Map<List<ChoiceDto>>(choiceDomain);

            return Ok(choiceDto);
        }

        [HttpGet]
        [Authorize(Roles = "Writer")]   
        [Route("current")]
        public async Task<IActionResult> GetAllForCurrentPageById(string id)
        {
            var choiceDomain = await choiceRepository.GetAllForCurrentPageByIdAsync(id);

            var choiceDto = mapper.Map<List<ChoiceDto>>(choiceDomain);

            return Ok(choiceDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var choiceDomain = await choiceRepository.GetByIdAsync(id);

            if (choiceDomain == null)
            {
                return NotFound();
            }

            var choiceDto = mapper.Map<ChoiceDto>(choiceDomain);

            return Ok(choiceDto);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddChoiceRequestDto addChoiceRequestDto)
        {
            var choiceDomain = mapper.Map<Choice>(addChoiceRequestDto);

            choiceDomain = await choiceRepository.CreateAsync(choiceDomain);

            var choiceDto = mapper.Map<ChoiceDto>(choiceDomain);

            return CreatedAtAction(nameof(GetById), new { id = choiceDto.Id }, choiceDto);
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateChoiceRequestDto updateChoiceRequestDto)
        {
            var choiceDomain = mapper.Map<Choice>(updateChoiceRequestDto);

            choiceDomain = await choiceRepository.UpdateAsync(id, choiceDomain);

            if (choiceDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ChoiceDto>(choiceDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var choiceDomain = await choiceRepository.DeleteAsync(id);

            if (choiceDomain == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
