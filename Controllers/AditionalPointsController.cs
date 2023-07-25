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
    public class AditionalPointsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAditionalPointRepository aditionalPointRepository;

        public AditionalPointsController(IMapper mapper, IAditionalPointRepository aditionalPointRepository)
        {
            this.mapper = mapper;
            this.aditionalPointRepository = aditionalPointRepository;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var aditionalPointDomain = await aditionalPointRepository.GetByIdAsync(id);

            if (aditionalPointDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AditionalPointDto>(aditionalPointDomain));
        }
    }
}
