﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISpellRepository spellRepository;

        public SpellsController(IMapper mapper, ISpellRepository spellRepository)
        {
            this.mapper = mapper;
            this.spellRepository = spellRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            var spellDomain = await spellRepository.GetAllAsync();

            return Ok(mapper.Map<List<SpellDto>>(spellDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var spellDomain = await spellRepository.GetByIdAsync(id);

            if (spellDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<SpellDto>(spellDomain));
        }
    }
}
