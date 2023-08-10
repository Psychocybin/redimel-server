using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redimel_server.CustomActionFilters;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;
using redimel_server.Repositories;
using System.Data;
using System.Net.WebSockets;

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
        public IActionResult GetAll()
        {


            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return Ok();
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
    }
}
