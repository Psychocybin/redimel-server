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
    public class PagesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPageRepository pageRepository;

        public PagesController(IMapper mapper, IPageRepository pageRepository)
        {
            this.mapper = mapper;
            this.pageRepository = pageRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetAll()
        {
            var pageDomain = await pageRepository.GetAllAsync();

            var pageDto = mapper.Map<List<PageDto>>(pageDomain);

            return Ok(pageDto);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var pageDomain = await pageRepository.GetByIdAsync(id);

            if (pageDomain == null)
            {
                return NotFound();
            }

            var pageDto = mapper.Map<PageDto>(pageDomain);

            return Ok(pageDto);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddPageRequestDto addPageRequestDto)
        {
            var pageDomain = mapper.Map<Page>(addPageRequestDto);

            pageDomain = await pageRepository.CreateAsync(pageDomain);

            var pageDto = mapper.Map<PageDto>(pageDomain);

            return CreatedAtAction(nameof(GetById), new { id = pageDto.Id }, pageDto);
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdatePageRequestDto updatePageRequestDto)
        {
            var pageDomain = mapper.Map<Page>(updatePageRequestDto);

            pageDomain = await pageRepository.UpdateAsync(id, pageDomain);

            if (pageDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PageDto>(pageDomain));
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var pageDomain = await pageRepository.DeleteAsync(id);

            if (pageDomain == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
