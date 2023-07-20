using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NatureSkillsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly INatureSkillRepository natureSkillRepository;

        public NatureSkillsController(IMapper mapper, INatureSkillRepository natureSkillRepository)
        {
            this.mapper = mapper;
            this.natureSkillRepository = natureSkillRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var natureSkillDomain = await natureSkillRepository.GetAllAsync();

            var natureSkillDto = mapper.Map<List<NatureSkillDto>>(natureSkillDomain);

            return Ok(natureSkillDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var natureSkillDomain = await natureSkillRepository.GetByIdAsync(id);

            if (natureSkillDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<NatureSkillDto>(natureSkillDomain));
        }
    }
}
