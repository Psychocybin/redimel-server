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
    public class PromisesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPromiseRepository promiseRepository;

        public PromisesController(IMapper mapper, IPromiseRepository promiseRepository)
        {
            this.mapper = mapper;
            this.promiseRepository = promiseRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            var promiseDomain = await promiseRepository.GetAllAsync();

            return Ok(mapper.Map<List<PromiseDto>>(promiseDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var promiseDomain = await promiseRepository.GetByIdAsync(id);

            if (promiseDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PromiseDto>(promiseDomain));
        }
    }
}
